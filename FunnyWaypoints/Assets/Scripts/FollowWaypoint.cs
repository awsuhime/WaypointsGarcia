using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public int currentWayPoint = 0;
    public float speed = 10f;
    public float rotSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {

       
        if (Vector3.Distance(waypoints[currentWayPoint].transform.position, transform.position) < 5f)
        {
            currentWayPoint++;
            if (currentWayPoint == waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        Quaternion LookAtWP = Quaternion.LookRotation(waypoints[currentWayPoint].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtWP, Time.deltaTime * rotSpeed);
        transform.Translate(0,0, speed * Time.deltaTime);

    }
}
