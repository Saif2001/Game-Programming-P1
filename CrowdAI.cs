using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdAI : MonoBehaviour
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
        transform.Translate(-Vector3.right * 0.03f);

        if (Physics.Raycast(transform.position, - transform.right, raycastLength))
        {
            transform.Translate(Vector3.right * 0.03f);
            Debug.Log("Something there");
            //transform.Rotate(new Vector3(0f, 0f, -0.2f));
            Invoke("delayTurn", 2);
        }

        if (Physics.Raycast(transform.position, transform.right, raycastLength))
        {
            Debug.Log("Something there");
            transform.Rotate(new Vector3(0f, 0f, 0.2f));
            Invoke("delayTurn", 2);
        }

        if (Physics.Raycast(transform.position, transform.up, raycastLength))
        {
            Debug.Log("Something there");
            Invoke("delayTurn", 2);
        }

    }

    void delayTurn()
    {
        float randTurnAngle = Random.Range(-0.5f, 0.2f);
        transform.Rotate(new Vector3(0f, 0f, randTurnAngle));
    }

}
