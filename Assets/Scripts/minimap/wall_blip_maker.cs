using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wall_blip_maker : MonoBehaviour {
    GameObject ptype;
    GameObject blip;
    GameObject player;
    GameObject minimap;

    // Use this for initialization
    void Start () {
        ptype = gameObject;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        minimap = GameObject.FindGameObjectsWithTag("Minimap")[0];
        blip = new GameObject();
        blip.AddComponent<RawImage>();
        blip.GetComponent<RawImage>().texture = Resources.Load("blip") as Texture2D;
        //blip.GetComponent<Image>().color = new Color(0, 0, 0);
        blip.AddComponent<blip>();
        //blip.GetComponent<blip>().Target = player.transform;
        blip.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(8, 8);
        blip.transform.parent = minimap.transform;
        blip.GetComponent<blip>().Target = ptype.transform;
        //minimap.GetComponent<Renderer>().receiveShadows = false;
        blip.GetComponent<RawImage>().enabled = false;
        blip.transform.localScale = new Vector3(1, 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        float distToPlayer = Vector3.Distance(player.transform.position, ptype.transform.position);
        float radius = ptype.GetComponentInChildren<Renderer>().bounds.extents.magnitude;
        if (distToPlayer <= radius*2)
        {
            blip.GetComponent<RawImage>().enabled = true;
        }
        //else blip.GetComponent<Image>().enabled = false;

    }

    void OnDrawGizmosSelected()
    {
        Vector3 center = ptype.GetComponentInChildren<Renderer>().bounds.center;
        float radius = ptype.GetComponentInChildren<Renderer>().bounds.extents.magnitude;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(center, radius);
    }
}
