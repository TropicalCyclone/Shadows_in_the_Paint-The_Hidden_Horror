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

    private bool _playerIsHiding;


    // Start is called before the first frame update
    void Start()
    {
        HashSet<Transform> targets = waypointManager.GetWayPoints();
        if (!_Agent)
        {
            _Agent = GetComponent<NavMeshAgent>();
        }
        targetPos = new List<Transform>(targets);
        /*
        foreach (Transform tr in Waypoints.GetComponentInChildren<Transform>())
        {
            targetPos.Add(tr.gameObject.transform);
        }
        */
        durationLeft = followDuration;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, _Player.position);

        if (distanceToPlayer <= playerFollowRange)
        {
            aiState = e_AI_State.FollowPlayer;
        }
        if (durationLeft <= 0f)
        {
            aiState = e_AI_State.Patrol;
        }
       

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


