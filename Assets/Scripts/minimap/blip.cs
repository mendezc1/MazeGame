using UnityEngine;
using System.Collections;

public class blip : MonoBehaviour {
    public Transform Target;
    minimap map;
    RectTransform myRectTransform;
    GameObject me;
	// Use this for initialization
	void Start () {
        me = gameObject;
        map = GetComponentInParent<minimap>();
        myRectTransform = me.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {
        Vector2 newPosition = map.TransformPosition(Target.position);
        myRectTransform.localPosition = newPosition;
    }
}
