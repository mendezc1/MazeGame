using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_properties : MonoBehaviour {
    public float health;
    public int mana;
    public int stamina;
    GameObject player;
    public bool poisoned;
    public Text HealthCounter;
	// Use this for initialization
	void Start () {
        player = this.gameObject;
        health = 100;
        mana = 100;
        stamina = 100;
        poisoned = false;
        setHealthText();
	}
	
	// Update is called once per frame
	void Update () {
        setHealthText();
        //health -= .1f;
        if (health <= 0)
        {

            player.transform.position = new Vector3(1, 20, 0);
            health = 100;
        }
	}
    public bool isPoisoned()
    {
        return poisoned;
    }

    void setHealthText()
    {
        HealthCounter.text = "Health: " + health.ToString();
    }
}
