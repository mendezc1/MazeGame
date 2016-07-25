using UnityEngine;
using System.Collections;

public class chalkline_properties : MonoBehaviour {
    public int marked_generations;
    private GameObject line;
    // Use this for initialization
    void Start()
    {
       //marked_generations = -1;
        line = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set_generations(int generations)
    {
        print("in set_generations (chalkline_properties");
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
            Destroy(line);
        }
    }
}