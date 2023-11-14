using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public enum e_AI_State
    {
        FollowPlayer,
        Patrol

    }

    [Header("References")]
    [SerializeField] private PlayerScriptManager _playerScriptManager;

    [SerializeField] private NavMeshAgent _Agent;

    [Header("Waypoints")]
    [SerializeField] private Waypoints _waypointManager;
    [SerializeField] private List<Transform> _targetPos;
    [SerializeField] private int _wayPointNumber;

    [SerializeField] private e_AI_State _aiState;

    [Header("Player follow settings")]
    [SerializeField] private float _playerFollowRange;
    [SerializeField] private float _crouchFollowRange;
    [SerializeField] private float _followDuration;
    [SerializeField] private float _durationLeft;
    [SerializeField] private float _enemyRoamSpeed;
    [SerializeField] private float _enemyAttackSpeed;

    private HashSet<Transform> targets;
    private bool _playerIsHiding;
    private bool _attack;
    private bool _runOnce;
    public bool _isAttacking { get { return _attack; } }

    private void OnEnable()
    {
        if (!_playerScriptManager)
        {
            _playerScriptManager = FindAnyObjectByType<PlayerScriptManager>();
        }
    }

    private Ray sight;
    // Start is called before the first frame update
    void Start()
    {
        targets = _waypointManager.GetWayPoints();
        _playerIsHiding = _playerScriptManager.Hide.GetStatus;


        if (!_Agent)
        {
            _Agent = GetComponent<NavMeshAgent>();
        }

        /*
        foreach (Transform tr in Waypoints.GetComponentInChildren<Transform>())
        {
            targetPos.Add(tr.gameObject.transform);
        }
        */
        _durationLeft = _followDuration;
        _targetPos = new List<Transform>(targets);
    }

    private void FixedUpdate()
    {
        sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        sight.direction = _playerScriptManager.PlayerMovement.transform.position - transform.position;
        RaycastHit rayHit;

        if (Physics.Raycast(sight, out rayHit, getFollowDistance()))
        {
            Debug.DrawLine(sight.origin, rayHit.point, Color.red);
            if (rayHit.transform.gameObject == _playerScriptManager.PlayerMovement.gameObject && !_playerIsHiding)
            {
                _runOnce = true;
                Debug.Log("attack");
                _durationLeft = _followDuration;
                _aiState = e_AI_State.FollowPlayer;
                _Agent.speed = _enemyAttackSpeed;
            }

            if (_durationLeft <= 0f || _playerIsHiding)
            {
                if (_runOnce)
                {
                    _Agent.ResetPath();
                    _runOnce = false;
                }
                _aiState = e_AI_State.Patrol;
                _Agent.speed = _enemyRoamSpeed;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerScriptManager.Hide.GetStatus != _playerIsHiding)
        {
            _playerIsHiding = _playerScriptManager.Hide.GetStatus;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _playerScriptManager.PlayerMovement.transform.position);

        switch (_aiState)
        {
            case e_AI_State.FollowPlayer:
                _Agent.SetDestination(_playerScriptManager.PlayerMovement.transform.position);

                if (_Agent.remainingDistance <= _Agent.stoppingDistance && !_Agent.pathPending)
                {
                    if (!_playerIsHiding)
                    {
                        _attack = true;
                    }
                }
                else
                {
                    _attack = false;
                }

                break;
            case e_AI_State.Patrol:
                if (_durationLeft < _followDuration)
                {
                    _durationLeft += Time.deltaTime;
                }
                //returns the distance of agent, if it is the same of stoping distance
                if (_Agent.remainingDistance <= _Agent.stoppingDistance && !_Agent.pathPending)
                {
                    if (!_Agent.hasPath || _Agent.velocity.sqrMagnitude == 0f)
                    {
                        MoveToRandomWaypoint();
                    }
                }
                break;
            default:
                break;
        }
    }
    public void MoveToRandomWaypoint()
    {

        //code if we forgot to add waypoints into the list
        if (_targetPos.Count == 0)
        {
            Debug.LogWarning("No waypoints available.");
            return;
        }

        //Make the bool moving true, get a random waypoint number
        int newWaypointIndex = GetRandomWaypointIndex();
        //if waypoint number is not the same as waypoint index, then proceed to destination
        if (newWaypointIndex != _wayPointNumber)
        {
            //we make this equal to random way point

            _wayPointNumber = newWaypointIndex;
            //Setting the agent new destination
            _Agent.SetDestination(_targetPos[_wayPointNumber].position);
        }
        else
        {
            // If the random waypoint is the same as the current one, find another waypoint
            Debug.Log("Setting new destination");
            MoveToRandomWaypoint();
        }
    }

    public int GetRandomWaypointIndex()
    {
        return Random.Range(0, _targetPos.Count);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, getFollowDistance());
    }

    private float getFollowDistance()
    {
        if (_playerScriptManager)
        {
            if (_playerScriptManager.PlayerMovement.GetCrouchStatus())
            {
                return _crouchFollowRange;
            }
            else
            {
                return _playerFollowRange;
            }
        }
        return _playerFollowRange;
    }
}


