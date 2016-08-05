using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour {
    public Transform target;
    // Use this for initialization
    void Start() {

    


    }

	// Update is called once per frame
	void Update () {
	
	}


    public Vector2 TransformPosition(Vector3 position)
    {
        Vector3 offset = position - target.position;
        Vector2 newPosition = new Vector2(offset.x, offset.z);
        return newPosition;
    }
}