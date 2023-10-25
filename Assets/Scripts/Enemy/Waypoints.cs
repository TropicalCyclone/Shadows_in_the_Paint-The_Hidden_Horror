using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    private HashSet<Transform> _wayPoints = new();

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            _wayPoints.Add(child.transform);
        }
    }

    public HashSet<Transform> GetWayPoints()
    {
        return _wayPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTransformChildrenChanged()
    {

    }
}
