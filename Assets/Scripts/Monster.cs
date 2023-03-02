using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Transform[] waypoints;
    private Transform targetWaypoint;
    private int waypointIndex;
    private bool isReverse;

    private void Awake()
    {

        targetWaypoint = waypoints[0];

    }

    // Update is called once per frame
    void Update()
    {
        //move to waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, Time.deltaTime * speed);

        if (transform.position == targetWaypoint.position)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint ()
    {
        if (waypointIndex >= waypoints.Length - 1)
        {
            isReverse = true;
            waypointIndex = waypoints.Length - 1;
        }
        else if (waypointIndex <= 0)
            isReverse = false;

        if (isReverse)
            waypointIndex--;
        else
            waypointIndex++;

        targetWaypoint = waypoints[waypointIndex];

    }

}
