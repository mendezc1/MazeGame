using UnityEngine;
using System.Collections;

public class enemy_pursuit : MonoBehaviour {
    public GameObject Player;
    public float MinDist;
    public float MoveSpeed;
    public float MaxDist;
    public GameObject enemy;
    public float distToPlayer;
    public bool allowedToMove;

	void Start () {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        enemy = gameObject;
        MinDist = .5f;
        MaxDist = 1f;
        MoveSpeed = 5f;
        //anim = enemy.GetComponentInChildren<Animator>();
        
        distToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        //anim.SetFloat("distToPlayer", distToPlayer);
    }
	
	// Update is called once per frame
	void Update () {
        if (allowedToMove)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, .5f, Player.transform.position.z));

            distToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            //print(distToPlayer);
            if (distToPlayer >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        }
    }
}
