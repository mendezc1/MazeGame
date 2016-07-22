using UnityEngine;
using System.Collections;

/// <summary>
/// In summary, JOHN CENA!!!!!!!!!!!!!!!!!!!!
/// </summary>
public class YouCantSeeMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // show
            //Destroy(gameObject);
//            transform.Translate(0, 200, 0  * Time.deltaTime, Space.World);
            foreach (var child in transform)
               {
                if (child.ToString() == "true")
                {

                    // the code here is called 
                    // for each child named Bone
                }
                else {

                    transform.Translate(0, 1, 0 * Time.deltaTime, Space.World);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // hide

            transform.Translate(0, -200, 0 * Time.deltaTime, Space.World);

        }
    }
}
