using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdAI : MonoBehaviour
{
    public float raycastLength = 10f;


    //Visualising Raycasts
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.right * (raycastLength));
        Gizmos.DrawRay(transform.position, transform.up * (raycastLength));
        Gizmos.DrawRay(transform.position, -transform.up * (raycastLength));
        
    }

    void Update()
    {
        //Move forward
        transform.Translate(-Vector3.right * 0.03f);

        //When an obstacle is detected to the front, left or right, delay reaction to prevent twitchiness
        if (Physics.Raycast(transform.position, - transform.right, raycastLength))
        {
            transform.Translate(Vector3.right * 0.03f);
            Invoke("delayTurn", 2);
        }

        if (Physics.Raycast(transform.position, transform.right, raycastLength))
        {
            transform.Rotate(new Vector3(0f, 0f, 0.2f));
            Invoke("delayTurn", 2);
        }

        if (Physics.Raycast(transform.position, transform.up, raycastLength))
        {
            Invoke("delayTurn", 2);
        }

    }

    void delayTurn()
    {
        float randTurnAngle = Random.Range(-0.5f, 0.2f);            //Random turn angle for unpredictability
        transform.Rotate(new Vector3(0f, 0f, randTurnAngle));
    }

}
