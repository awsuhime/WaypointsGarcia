using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypoints : MonoBehaviour {

   

    GameObject[] wps;
    GameObject currentNode;
    NavMeshAgent agent;

    

    public GameObject wpManager;

    void Start() {
        Time.timeScale = 5.0f;
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        currentNode = wps[0];

        agent = GetComponent<NavMeshAgent>();

        // Invoke("GotoRuin", 2.0f);
    }

    public void GotoHeli() {

        GotoHere(3);
    }

    public void GotoNowhere() {

        //g.AStar(currentNode, wps[7]);
        //currentWP = 0;

        GotoHere(5);
    }

    public void GotoRock() {

        //g.AStar(currentNode, wps[1]);
        //currentWP = 0;
        GotoHere(2);
    }

    public void GotoFactory() {

        //g.AStar(currentNode, wps[4]);
        //currentWP = 0;
        GotoHere(4);
    }

    void GotoHere(int value) {

        agent.SetDestination(wps[value].transform.position);
    }

    void LateUpdate() {

        
    }
}
