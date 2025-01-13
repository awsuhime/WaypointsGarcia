using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    Transform goal;
    public float speed = 5.0f;
    float accuracy = 1.0f;
    public float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        g = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[3];
        Invoke("GoToSpire", 2);
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[3]);
        currentWP = 3;

        
    }

    public void GoToSpire()
    {
        g.AStar(currentNode, wps[2]);
        currentWP = 2;
    }

    public void GoToNowhere()
    {
        g.AStar(currentNode, wps[5]);
        currentWP = 5;
    }

    public void GoToFactory()
    {
        g.AStar(currentNode, wps[4]);
        currentWP = 4;
    }

    void LateUpdate()
    {
        if(g.pathList.Count == 0 || currentWP == g.pathList.Count){
            return;
        }
        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }
        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
