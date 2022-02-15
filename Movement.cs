using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int myInt = 125;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myInt);
    }

    // Update is called once per frame
    void Update()
    {
        bool moveHor = Input.GetButton("Horizontal");
        bool moveFwd = Input.GetButton("Vertical");

        float directionHor = Input.GetAxis("Horizontal");
        float directionFwd = Input.GetAxis("Vertical");


        if (moveFwd)
        {
            if (directionFwd > 0)
            {
                transform.Translate(3* Vector3.forward * Time.deltaTime);
            }
            if(directionFwd < 0)
            {
                transform.Translate(3* Vector3.back * Time.deltaTime);
            }
        }


        if (moveHor)
        {
            if (directionHor > 0)
            {
                transform.Translate(3 * Vector3.right * Time.deltaTime);
            }
            if (directionHor < 0)
            {
                transform.Translate(3 * Vector3.left * Time.deltaTime);
            }
        }


    }
}
