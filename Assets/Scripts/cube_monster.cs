using UnityEngine;
using System.Collections;

public class cube_monster : Actor {
    // This var will determine if the animation is started
    public bool animation_started = false;
    // This var will determine if the animation is finished
    public bool animation_finished = true;
    // Use this for initialization
    public Animator anim;
    void Start () {
        health = 100;
        mana = 100;
        actor = this.gameObject;
        print(this.name);
        this.tag = "Enemy";
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.parent.GetComponent<enemy_pursuit>().allowedToMove = true;
    }

    // Update is called once per frame
    void Update () {
        kill();
        setHealthText();



        if (gameObject.transform.parent.GetComponent<enemy_pursuit>().distToPlayer < 3 && !animation_started)
        {

            // initialize the flags
            animation_started = true;
            animation_finished = false;
            gameObject.transform.parent.GetComponent<enemy_pursuit>().allowedToMove = false;
            // Start the animation
            // this animation moves the box from local X = 0 to X = 10 using a curve to deaccelerate
            print("setting attacking to true.");
            anim.SetTrigger("attacking");
        }
        //print (health);
    }




 
    /* This function is trigger at the end of the animation */
    public void animationFinished(){
        animation_finished = true;
        transform.parent.position = new Vector3(transform.position.x, .5f, transform.position.z);
        transform.parent.rotation = transform.rotation;

    }

/*  
    At the end of the frame if the animation is finished
    we update the position of the parent to the last position of the child
    and set the position of the child to zero inside the parent.
*/
    void LateUpdate()
    {
        // if the animation is finished and it was started
        if (animation_finished && animation_started)
        {
            // set the flag
            print("oh yeah");
            animation_started = false;
            // update the parent position
            
            // update the box position to zero inside the parent
            transform.localPosition = Vector3.zero;
            gameObject.transform.parent.GetComponent<enemy_pursuit>().allowedToMove = true;
        }
    }
}
