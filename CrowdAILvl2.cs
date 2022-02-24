using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdAILvl2 : MonoBehaviour
{
    public float raycastLength = 0.3f;

    //Simpler crowd AI for Level 2 (Bugs)
    //Visualising raycasts
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.up * (raycastLength));
        Gizmos.DrawRay(transform.position, -transform.up * (raycastLength));

    }


    

    void Update()
    {
        
        //Avoiding obstacles on all sides by raycasting and rotating as appropriate
        if (Physics.Raycast(transform.position, transform.right, raycastLength))
        {
            transform.Rotate(0f, 0f, 30f);
            transform.Translate(Vector3.left * 0.001f);  
        }
        else if (Physics.Raycast(transform.position, -transform.right, raycastLength))
        {
            transform.Rotate(0f, 0f, -30f);
            transform.Translate(-Vector3.left * 0.001f);
        }
        else if (Physics.Raycast(transform.position, -transform.up, raycastLength))
        {
            transform.Rotate(0f, 0f, -45f);
            transform.Translate(Vector3.up * 0.001f);
        }
        else if (Physics.Raycast(transform.position, transform.up, raycastLength))
        {
            transform.Rotate(0f, 0f, 45f);
            transform.Translate(-Vector3.up * 0.001f);
        }
        else
        {
            //Move if unobstructed
            transform.Translate(Vector3.up * 0.003f);
        }
    }


}
