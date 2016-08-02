using UnityEngine;
using System.Collections;

public class chalk_properties : MonoBehaviour {
    //#generations chalk will last for.
    public int power;
    public int uses;
	// Use this for initialization
	void Start () {
        power = 3;
        uses = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void set_power(int new_power)
    {
        power = new_power;
    }

    public void decrement_uses()
    {
        if(uses> 0)
        {
            uses--;
        }
        if (uses == 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    public int get_power()
    {
        //print("getting power");
        return power;
    }

    public int random_power_level()
    {
        return Random.Range(1, 5);
    }
}
