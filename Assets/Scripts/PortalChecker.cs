using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalChecker : MonoBehaviour {
    GameObject startBlock;
    GameObject goal;
    public bool portalConnected;
    public int num_times;

	// Use this for initialization
	void Start () {
        print("in start");
        goal = this.gameObject;
        GameObject[] startBlocks = GameObject.FindGameObjectsWithTag("Home");
        startBlock = startBlocks[0];
        print("found home");
        portalConnected = false;
        num_times = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (goal.tag == "marked_block" && portalConnected == false && num_times == 0)
        {
           
            portalConnected = isportalconnected(startBlock, goal, new List<GameObject>(), new List<GameObject>());
            print(portalConnected);
            num_times++;
        }
        
	}
    bool isportalconnected(GameObject start, GameObject goal, List<GameObject> connectedPath, List<GameObject> visitedCubes)
    {
        
        connectedPath.Add(start);
        while (connectedPath.Count > 0)
        {
            List<GameObject> neighbours = findAllMarkedNeighbors(connectedPath[0]);
            print(neighbours.Count);
            foreach (GameObject neighbour in neighbours)
            {
                print("neighbor is: " +neighbour.tag);
                if (!visitedCubes.Contains(neighbour))
                {
                    if (neighbour.transform.position == goal.transform.position)
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
            //print("collider tag = "+ coll.gameObject.tag);
            if (coll.gameObject.tag == "marked_block" || coll.gameObject.tag == "Home"){
                markedNeighbours.Add(coll.gameObject);
            }
        }
        //print(markedNeighbours[0]);
        return markedNeighbours;
    }
}
