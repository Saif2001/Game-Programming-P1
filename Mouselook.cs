using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouselook : MonoBehaviour
{

    public float Sensitivity = 100;

    public Transform playerObject;
    public Transform playerCam;

    float xRotation = 0f;

    public bool CanFireOffGround;

    public Intro other;

    // Start is called before the first frame update
    void Start()
    {
        //playerObject.position = new Vector3(-27.67f, 8.21f, -23.14f);
        //playerObject.Rotate(20f, -138.6f, 0.452f);

        //yield return new WaitForSeconds(5);
        //playerObject.Rotate(0f, 0f, 0f);

        Cursor.lockState = CursorLockMode.Locked;   
   
    }


// Update is called once per frame
void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerObject.Rotate(Vector3.up * mouseX);

        float lookRotation = Vector3.SignedAngle(Vector3.up, transform.up, transform.forward);
        //float lookRotationZ = playerCam.eulerAngles.z;
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //playerObject.Translate(0f, lookRotation * 0.001f, -0.5f) ;
            playerObject.GetComponent<Rigidbody>().AddForce((-transform.forward) * 75, ForceMode.Impulse);
        }


        // Debug.Log("Camera Rotation X: " + playerCam.eulerAngles.x);
        //Debug.Log("Camera Rotation Y: " + playerCam.eulerAngles.y);
        //Debug.Log("Camera Rotation Z: " + playerCam.eulerAngles.z);

 

        
    }
}
