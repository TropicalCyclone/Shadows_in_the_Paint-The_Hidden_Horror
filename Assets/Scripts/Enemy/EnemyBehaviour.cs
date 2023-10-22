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
    [SerializeField] private Transform _Player;
    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private Hide HideScript;

    [Header("Waypoints")]
    [SerializeField] private Waypoints waypointManager;
    [SerializeField] private Transform Waypoints;
    [SerializeField] private List<Transform> targetPos;
    [SerializeField] private int wayPointNumber;

    [SerializeField] private e_AI_State aiState;

    [Header("Player")]
    [SerializeField] private float playerFollowRange;
    [SerializeField] private float followDuration;
    [SerializeField] private float durationLeft;

    
    private HashSet<Transform> targets;
    private bool _playerIsHiding;

    private Ray sight;
    // Start is called before the first frame update
    void Start()
    { 
        targets = waypointManager.GetWayPoints();
        _playerIsHiding = HideScript.GetStatus;
   
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
        durationLeft = followDuration;
        targetPos = new List<Transform>(targets);
    }

    private void FixedUpdate()
    {
        sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        sight.direction = _Player.transform.position - transform.position;
        RaycastHit rayHit;

        if (Physics.Raycast(sight, out rayHit, playerFollowRange))
        {
            Debug.DrawLine(sight.origin, rayHit.point, Color.red);
            if (rayHit.transform.gameObject == _Player.gameObject && !_playerIsHiding)
            {
                aiState = e_AI_State.FollowPlayer;
            }

            if (durationLeft <= 0f || _playerIsHiding)
            {
                
              aiState = e_AI_State.Patrol;
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (HideScript.GetStatus != _playerIsHiding)
        {
            _playerIsHiding = HideScript.GetStatus;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _Player.position);

        switch (aiState)
        {
            case e_AI_State.FollowPlayer:
                _Agent.SetDestination(_Player.position);
                if(distanceToPlayer > playerFollowRange)
                durationLeft -= Time.deltaTime;
                break;
            case e_AI_State.Patrol:
                if (durationLeft < followDuration)
                {
                    durationLeft += Time.deltaTime;
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
        if (targetPos.Count == 0)
        {
            Debug.LogWarning("No waypoints available.");
            return;
        }

        //Make the bool moving true, get a random waypoint number
        int newWaypointIndex = GetRandomWaypointIndex();
        //if waypoint number is not the same as waypoint index, then proceed to destination
        if (newWaypointIndex != wayPointNumber)
        {
            //we make this equal to random way point
            wayPointNumber = newWaypointIndex;
            //Setting the agent new destination
            _Agent.SetDestination(targetPos[wayPointNumber].position);
        }
        else
        {
            // If the random waypoint is the same as the current one, find another waypoint
            MoveToRandomWaypoint();
        }
    }

    public int GetRandomWaypointIndex()
    {
        return Random.Range(0, targetPos.Count);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerFollowRange);
    }
}


