using System.Collections.Generic;
using UnityEngine;
//TODO: delete chalk lines after parent generations have expired.
public class draw_chalk : MonoBehaviour
{
    List<Vector3> linePoints = new List<Vector3>();
    LineRenderer lineRenderer;
    public float startWidth = .001f;
    public float endWidth = .001f;
    public float threshold = 0.001f;
    Camera thisCamera;
    int lineCount = 0;
    public GameObject chalk;
    GameObject go;

    Vector3 lastPos = Vector3.one * float.MaxValue;


    void Awake()
    {
        thisCamera = Camera.main;
        chalk = this.gameObject;

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
        if (Input.GetMouseButtonDown(0))
        {
            go = new GameObject();
            
            go.transform.parent = chalk.transform.parent;
            go.tag = "chalk_line";
            lineRenderer = go.AddComponent<LineRenderer>();
            add_chalk_properties(go);

            Vector3 newPoint = Caster().point;
            lastPos = newPoint;
            lineRenderer.SetWidth(.01f, .01f);
            lineRenderer.SetPosition(0,newPoint);
            lineRenderer.SetPosition(1, newPoint);
            
            
            linePoints = new List<Vector3>();
            linePoints.Add(newPoint);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = thisCamera.nearClipPlane + .01f;
            Vector3 mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);

            float dist = Vector3.Distance(lastPos, mouseWorld);
            if (dist <= threshold)
                return;
            RaycastHit casterObj = Caster();
            Vector3 newPoint = casterObj.point;
            print(casterObj.collider.gameObject.name);
            if (casterObj.collider.gameObject.name == "Cube")
            {
                GameObject cube = casterObj.collider.gameObject;
                if (cube.tag != "marked_block")
                {
                    cube.tag = "marked_block";
                    chalk.GetComponent<chalk_properties>().decrement_uses();

                }
                cube.GetComponent<block_properties>().set_generations(chalk.GetComponent<chalk_properties>().get_power());
                float distToCube = Vector3.Distance(chalk.transform.position, casterObj.point);
                if (distToCube < 3.5f)
                {
                    //Material cubeMat = cube.GetComponent<Material>();

                    lastPos = newPoint;
                    if (linePoints == null)
                        linePoints = new List<Vector3>();
                    linePoints.Add(newPoint);

                    UpdateLine();
                }
            }
        }
       // else {
       //     Vector3 newPoint = Caster().point;
       //     lastPos = newPoint;
       //     linePoints.Clear();
       //     lineRenderer = GetComponent<LineRenderer>();
       // }

       

    }

    void add_chalk_properties(GameObject obj)
    {
        obj.AddComponent<chalkline_properties>();
        print("Calling set generations");
        //print(obj.GetComponent<chalkline_properties>().get_generations());
        obj.GetComponent<chalkline_properties>().set_generations(chalk.GetComponent<chalk_properties>().get_power());
        //print(obj.GetComponent<chalkline_properties>().get_generations());
    }

    void UpdateLine()
    {
        
        lineRenderer.SetVertexCount(linePoints.Count);

        for (int i = lineCount; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i]);
        }
        lineCount = linePoints.Count;
        
    }


    RaycastHit Caster()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.point);
            //print(hit.collider.name);
        }
        return hit;
    }

}





