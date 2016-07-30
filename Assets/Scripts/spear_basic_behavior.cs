using UnityEngine;
using System.Collections;

public class spear_basic_behavior : MonoBehaviour {
    Animator anim;
    GameObject spear;
    float startTime;
    Animation attackClip;
    float clipLength;
    // Use this for initialization
    void Start() {
        spear = this.gameObject;
        anim = spear.GetComponent<Animator>();
        startTime = Time.time;
        clipLength = 0;

    }

    // Update is called once per frame
    void Update() {
        ///anim.SetBool("attack", false);


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
            //print(anim.GetBool("attack"));
        }
        
	}
}
