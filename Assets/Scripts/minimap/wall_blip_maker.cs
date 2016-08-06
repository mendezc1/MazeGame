using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wall_blip_maker : MonoBehaviour {
    GameObject ptype;
    GameObject blip;

	// Use this for initialization
	void Start () {
        ptype = gameObject;
        GameObject minimap = GameObject.FindGameObjectsWithTag("Minimap")[0];
        blip = new GameObject();
        blip.AddComponent<Image>();
        blip.GetComponent<Image>().color = new Color(0, 0, 0);
        blip.AddComponent<blip>();
        //blip.GetComponent<blip>().Target = player.transform;
        blip.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(8, 8);
        blip.transform.parent = minimap.transform;
        blip.GetComponent<blip>().Target = ptype.transform;
        blip.GetComponent<Image>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (ptype.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            blip.GetComponent<Image>().enabled = true;
        }
        else blip.GetComponent<Image>().enabled = false;

    }
}
