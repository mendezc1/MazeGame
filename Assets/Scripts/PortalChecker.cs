using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalChecker : MonoBehaviour {
    GameObject startBlock;
    GameObject goal;
    public bool portalConnected;

	// Use this for initialization
	void Start () {
        print("in start");
        goal = this.gameObject;
        GameObject[] startBlocks = GameObject.FindGameObjectsWithTag("Home");
        startBlock = startBlocks[0];
        print("found home");
        portalConnected = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (goal.tag == "marked_block" && portalConnected == false)
        {
            print("calling isportalconnected");
            portalConnected = isportalconnected(startBlock, goal);
            print(portalConnected);
        }
        
	}
    bool isportalconnected(GameObject start, GameObject goal)
    {
        print("in isportalconnected");

        
        List<GameObject> connectedPath = new List<GameObject>();
        List<GameObject> visitedCubes = new List<GameObject>();

        connectedPath.Add(start);
        while (connectedPath.Count > 0)
        {
            List<GameObject> neighbours = findAllMarkedNeighbors(connectedPath[0]);
            foreach (GameObject neighbour in neighbours)
            {
                if (!visitedCubes.Contains(neighbour))
                {
                    if (neighbour == goal)
                    {
                        return true;
                    }
                    connectedPath.Add(neighbour);
                }
            }
            visitedCubes.Add(connectedPath[0]);
            connectedPath.RemoveAt(0);
        }

        //for each neighbor of start
        //if neighbor is goal, return true
        //if neighbor is not goal and is marked, return isportalconnected(neighbor, goal)
        //if neighbor is not goal and is not marked, return false
        
        return false;
        
    }

    List<GameObject> findAllMarkedNeighbors(GameObject go)
    {
        List<GameObject> markedNeighbours = new List<GameObject>();
        Collider[] colliders = Physics.OverlapSphere(go.transform.position, go.GetComponent<Collider>().bounds.size.x);
        foreach (Collider coll in colliders)
        {
            if (coll.gameObject.tag == "marked_cube" || coll.gameObject.tag == "Home");
            {
                markedNeighbours.Add(coll.gameObject);
            }
        }
        return markedNeighbours;
    }
}
