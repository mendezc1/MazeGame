using UnityEngine;
using System.Collections;

public class block_properties : MonoBehaviour {
    public int marked_generations;
    private GameObject block;
	// Use this for initialization
	void Start () {
        marked_generations = -1;
        block = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void set_generations(int generations)
    {
       if (marked_generations <= generations)
        {
            marked_generations = generations;
        }
        
    }

    public int get_generations()
    {
        return marked_generations;
    }

    public void decrement_generation()
    {
        if (marked_generations > 0)
        {
            marked_generations -= 1;
        }
        if (marked_generations == 0)
        {
            marked_generations = -1;
            if(block.transform.position.x==0 || block.transform.position.z == 0 || block.transform.position.x == GameObject.Find("Terrain").GetComponent<MazeGenerator>().get_width()-1 || block.transform.position.z == GameObject.Find("Terrain").GetComponent<MazeGenerator>().get_height() - 1)
            {
                block.tag = "edge_block";
            }
           else
           {
                block.tag = "unmarked_block";
           }
            

        }
    }
}
