using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    private HashSet<Transform> wayPoints = new();

    public GameObject Go { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Go = gameObject;

        foreach (Transform child in transform)
        {
            wayPoints.Add(child.transform);
        }
    }

    public HashSet<Transform> GetWayPoints()
    {
        return wayPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTransformChildrenChanged()
    {

    }
}
