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
    [SerializeField] private PlayerMovement _Player;
    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private Hide _hideScript;

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

    
    private HashSet<Transform> targets;
    private bool _playerIsHiding;

    private Ray sight;
    // Start is called before the first frame update
    void Start()
    { 
        targets = _waypointManager.GetWayPoints();
        _playerIsHiding = _hideScript.GetStatus;
   
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
        sight.direction = _Player.transform.position - transform.position;
        RaycastHit rayHit;

        if (Physics.Raycast(sight, out rayHit, getFollowDistance()))
        {
            Debug.DrawLine(sight.origin, rayHit.point, Color.red);
            if (rayHit.transform.gameObject == _Player.gameObject && !_playerIsHiding)
            {
                _durationLeft = _followDuration;
                _aiState = e_AI_State.FollowPlayer;
            }

            if (_durationLeft <= 0f || _playerIsHiding)
            {
              _Agent.ResetPath();
              _aiState = e_AI_State.Patrol;
              MoveToRandomWaypoint();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_hideScript.GetStatus != _playerIsHiding)
        {
            _playerIsHiding = _hideScript.GetStatus;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _Player.transform.position);

        switch (_aiState)
        {
            case e_AI_State.FollowPlayer:
                _Agent.SetDestination(_Player.transform.position);
                if(distanceToPlayer > getFollowDistance())
                _durationLeft -= Time.deltaTime;
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
        if (_Player.GetCrouchStatus())
        {
            return _crouchFollowRange;
        }
        else
        {
            return _playerFollowRange;
        }
    }
}


