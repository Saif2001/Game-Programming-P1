using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    void Update()
    {

        //Different axes according to Unity's input manager
        bool moveHor = Input.GetButton("Horizontal");
        bool moveFwd = Input.GetButton("Vertical");

        float directionHor = Input.GetAxis("Horizontal");
        float directionFwd = Input.GetAxis("Vertical");

        bool jump = Input.GetButtonDown("Jump");

        if (moveFwd)
        {
            //Forward and backward movement
            if (directionFwd > 0)
            {
                transform.Translate(10* Vector3.forward * Time.deltaTime);
            }
            if(directionFwd < 0)
            {
                transform.Translate(10* Vector3.back * Time.deltaTime);
            }
        }


        if (moveHor)
        {
            //Left and Right movement
            if (directionHor > 0)
            {
                transform.Translate(10 * Vector3.right * Time.deltaTime);
            }
            if (directionHor < 0)
            {
                transform.Translate(10 * Vector3.left * Time.deltaTime);
            }
        }

        if (jump)
        {
            //Addforce is more organic than translating in y direction

            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 2000f, 0f));

        }

    }
}
