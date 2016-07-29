using UnityEngine;
using System.Collections;

public class poison_trap_trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag);
        if(other.tag == "Player")
        {
            GameObject par = this.gameObject.transform.parent.gameObject;
            par.GetComponent<Poison_trap>().trigger_poison(other.gameObject);
            //Light light = this.gameObject.transform.parent.gameObject.GetComponent<Light>();
            //light;
            print("Git Gud");
        }
    }
}
