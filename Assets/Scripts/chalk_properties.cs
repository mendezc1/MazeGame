using UnityEngine;
using System.Collections;

public class chalk_properties : MonoBehaviour {
    //#generations chalk will last for.
    public int power;
	// Use this for initialization
	void Start () {
        power = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void set_power(int new_power)
    {
        power = new_power;
    }
    
    public int get_power()
    {
        return power;
    }
}
