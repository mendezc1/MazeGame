using UnityEngine;
using System.Collections;

public class cube_monster_hitbox : MonoBehaviour {
    bool attacked;
    float attackTime;
	// Use this for initialization
	void Start () {
        attacked = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
        //print("Git Gud");
        //print (other.name);
        if (other.name == "spear" && other.transform.parent.GetComponent<spear_basic_behavior>().attacking == true && attacked == true)
        {
            if(Time.time - attackTime <= other.transform.parent.GetComponent<spear_basic_behavior>().clipLength)
            {
                attacked = false;
            }
        }
        //print(attacked);
        if (other.name == "spear" && other.transform.parent.GetComponent<spear_basic_behavior>().attacking == true && attacked == false) {

            print( attacked);
            this.transform.parent.GetComponent<cube_monster>().health -=.1f;
            print(this.transform.parent.GetComponent<cube_monster>().health);
            attackTime = Time.time;
            attacked = true;
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        //print("Git Gud");
        //print(other.name);
        if (other.name == "spear" && other.transform.parent.GetComponent<spear_basic_behavior>().attacking == true)
        {

            this.transform.parent.GetComponent<cube_monster>().health -= .1f;
            print(this.transform.parent.GetComponent<cube_monster>().health);
        }

    }
}
