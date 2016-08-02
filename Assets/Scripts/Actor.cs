using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour
{
    public float health { get; set; }
    public int mana { get; set; }
    public int stamina { get; set; }
    protected GameObject actor { get; set; }
    GameObject[] equipment;
    GameObject[] inventory;
    public GameObject hitbox;
    // Use this for initialization
    void Start()
    {
        actor = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //checkForHits();
    }
    
    public void kill()
    {
        //print(this.health);
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    bool checkForHits()
    {
        return true;
    }

    
}
