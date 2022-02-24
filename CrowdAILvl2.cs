using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdAILvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float raycastLength = 10f;


// Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.up * (raycastLength));
        Gizmos.DrawRay(transform.position, -transform.up * (raycastLength));

    }


    

    void Update()
    {
        //Ray frontSensor = Physics.Raycast(transform.position, transform.forward, (raycastLength + transform.localScale.x));
        

        if (Physics.Raycast(transform.position, transform.right, raycastLength))
        {
            //Debug.Log("Something there");
            transform.Rotate(0f, 0f, 30f);
            transform.Translate(Vector3.left * 0.001f);  
        }
        else if (Physics.Raycast(transform.position, -transform.right, raycastLength))
        {
            //Debug.Log("Something there");
            transform.Rotate(0f, 0f, -30f);
            transform.Translate(-Vector3.left * 0.001f);
        }
        else if (Physics.Raycast(transform.position, -transform.up, raycastLength))
        {
            //Debug.Log("Something there");
            transform.Rotate(0f, 0f, -45f);
            transform.Translate(Vector3.up * 0.001f);
        }
        else if (Physics.Raycast(transform.position, transform.up, raycastLength))
        {
            Debug.Log("Something there");
            transform.Rotate(0f, 0f, 45f);
            transform.Translate(-Vector3.up * 0.001f);
        }
        else
        {
            transform.Translate(Vector3.up * 0.003f);
        }
    }


}
