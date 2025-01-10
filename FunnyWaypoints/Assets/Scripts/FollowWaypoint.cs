using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public int currentWayPoint = 0;
    public float speed = 10f;
    public float rotSpeed = 10f;
    public float lookAhead = 10.0f;
    GameObject tracker;

    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = transform.position;
        tracker.transform.rotation = transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(transform.position, tracker.transform.position) < lookAhead)
        {
            if (Vector3.Distance(tracker.transform.position, transform.position) < 5f)
            {
                currentWayPoint++;
                if (currentWayPoint == waypoints.Length)
                {
                    currentWayPoint = 0;
                }
            }

            tracker.transform.LookAt(waypoints[currentWayPoint].transform);
            tracker.transform.Translate(0, 0, speed * 2 * Time.deltaTime);
        }
        
    }

 

    void Update()
    {

        ProgressTracker();
        
        Quaternion LookAtWP = Quaternion.LookRotation(tracker.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtWP, Time.deltaTime * rotSpeed);
        transform.Translate(0,0, speed * Time.deltaTime);

    }
}
