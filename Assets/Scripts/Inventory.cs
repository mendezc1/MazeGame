using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
   public ArrayList inventory;
	// Use this for initialization
	void Start () {
        inventory = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void addItemToInventory(GameObject item) 
    {
        inventory.Add(item);      
    }
}
