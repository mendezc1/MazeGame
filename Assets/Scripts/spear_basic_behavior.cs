﻿using UnityEngine;
using System.Collections;

public class spear_basic_behavior : MonoBehaviour {
    Animator anim;
    GameObject spear;
    float startTime;
    Animation attackClip;
    public float clipLength;
    public bool attacking { get; set; }
    public GameObject player;
    public int damage;
    // Use this for initialization
    void Start() {
        spear = this.gameObject;
        anim = spear.GetComponent<Animator>();
        startTime = Time.time;
        clipLength = 0;
        attacking = false;
        damage = 50;
        player = spear.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update() {
        ///anim.SetBool("attack", false);

        if (clipLength + startTime >= Time.time)
        {
            attacking = true;
        }
        else attacking = false;
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && clipLength + startTime <= Time.time) 
        {
            //print(anim.GetBool("attack"));
            startTime = Time.time;
            anim.SetTrigger("attackTrigger");
            foreach (AnimationClip ac in anim.runtimeAnimatorController.animationClips )
            {
                if(ac.name == "spear_attack_1" && clipLength == 0)
                {
                    clipLength = ac.length*.75f;
                }
            }
            RaycastHit casterObj = Caster();
            float distToRay = Vector3.Distance(player.transform.position, casterObj.point);
            //print(casterObj.collider.gameObject.tag);
            if (distToRay < 3f && casterObj.collider.gameObject.tag == "Enemy")
            {
                casterObj.collider.gameObject.GetComponent<Actor>().health -= damage;
                print(casterObj.collider.gameObject.GetComponent<Actor>().health);
                print("hit!");
            }
            //print(anim.GetBool("attack"));
        }
        
	}

    RaycastHit Caster()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        print("casting");
        
        if (Physics.Raycast(ray, out hit))
        {
           Debug.DrawLine(transform.position, hit.point, Color.cyan, 3);
            
            //print(hit.point);
            //print(hit.collider.name);
        }
        return hit;
    }
}
