using UnityEngine;
using System.Collections;

public class cube_monster : Actor {

	// Use this for initialization
	void Start () {
        health = 100;
        mana = 100;
        actor = this.gameObject;
        //base.hitbox = actor.GetComponent<Collider>();
        hitbox = Instantiate(new GameObject());
        hitbox.transform.parent = actor.transform;
        hitbox.AddComponent<BoxCollider>();
        hitbox.GetComponent<BoxCollider>().isTrigger = true;
        hitbox.transform.position = actor.transform.position;
        //hitbox.GetComponent<BoxCollider>().transform.localScale = new Vector3(actor.GetComponent<Collider>().transform.localScale.x * 6, actor.GetComponent<Collider>().transform.localScale.y * 4, actor.GetComponent<Collider>().transform.localScale.z * 6);
        hitbox.AddComponent<cube_monster_hitbox>();
    }

    // Update is called once per frame
    void Update () {
        kill();
        //health = health - 1;
        
        //print (health);
	}


}
