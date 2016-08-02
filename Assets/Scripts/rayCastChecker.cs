 using UnityEngine;
 using System.Collections;
 
 public class rayCastChecker : MonoBehaviour
 {
     Ray ray;
     RaycastHit hit;
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             //print(hit.point);
             //print (hit.collider.name);
         }
     }
 }