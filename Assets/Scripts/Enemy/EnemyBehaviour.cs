using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private Transform _Player;
    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private Transform Waypoints;
    [SerializeField] private List<Transform> targetPos;
    [SerializeField] private int wayPointNumber;
    [SerializeField] private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        if (!_Agent)
        {
            _Agent = GetComponent<NavMeshAgent>();
        }
        foreach (Transform tr in Waypoints.GetComponentInChildren<Transform>())
        {
            targetPos.Add(tr.gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_Agent.pathPending)
        {
            //returns the distance of _Agent, if it is the same of stoping distance
            if (_Agent.remainingDistance <= _Agent.stoppingDistance)
            {
                //if _Agent has no path or _Agent is standing still
                if (!_Agent.hasPath || _Agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    Debug.Log("DestinationReached");
                    MoveToRandomWaypoint();
                }


            }
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
        isMoving = true;
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
}


