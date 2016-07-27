using UnityEngine;
using System.Collections;

public class Poison_trap : MonoBehaviour {
    public float duration;
    public int drain_factor;
    public float endTime;
    public int drainsLeft;
    public float startTime;
    GameObject trap;
    GameObject player;
    // Use this for initialization
    void Start () {
        trap = this.gameObject;
        duration = 5f;
        drain_factor = 5;
        
	}
    void Awake()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit casterObj = Caster();
        float distToPlayer = Vector3.Distance(trap.transform.position, casterObj.point);

        if (distToPlayer < 5f)
        {
            if (casterObj.collider.name == "RigidBodyFPSController")
            {
                print(startTime - Time.time);
                if (Time.time - startTime >= 1)
                {
                    startTime = Time.time;

                    player = casterObj.collider.gameObject;

                    if (!player.GetComponent<player_properties>().isPoisoned())
                    {
                        InvokeRepeating("poison", 0, 1f);
                        player.GetComponent<player_properties>().poisoned = true;

                    }
                }
                
            }
        }
    }    

    void poison()
    {
        print(startTime + duration);
        print(Time.time);
        if (startTime + duration < Time.time)
        {
            player.GetComponent<player_properties>().poisoned = false;
            CancelInvoke();
        }
        player.GetComponent<player_properties>().health -= drain_factor;

    }
    RaycastHit Caster()
    {
        RaycastHit hit;
          if (Physics.Raycast(trap.transform.position, trap.transform.forward, out hit))
        {
            //print(hit.point);
            //print(hit.collider.name);
        }
        return hit;
    }

}
