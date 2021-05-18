using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private List<Transform> waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks to the next one
    private int waypointIndex = 0;

	// Use this for initialization
	void Start () 
    {
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            waypoints.Add(child.transform);
        }
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Move Enemy
        Move();
	}

    // Method that actually makes the Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }else{
            waypointIndex = 0;
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }
}
