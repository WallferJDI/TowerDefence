using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private bool movementPermit = false;
    public float camSpeed ;
    public float borderOffset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            movementPermit =! movementPermit;

        Movement();
        

       
    }
    void Movement()
    {
        if (movementPermit)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderOffset)
                transform.Translate(Vector3.forward * camSpeed * Time.deltaTime, Space.World);
            else if (Input.GetKey("s") || Input.mousePosition.y <= borderOffset)
                transform.Translate(Vector3.back * camSpeed * Time.deltaTime, Space.World);
            else if (Input.GetKey("a") || Input.mousePosition.x < borderOffset)
                transform.Translate(Vector3.left * camSpeed * Time.deltaTime, Space.World);
            else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderOffset)
                transform.Translate(Vector3.right * camSpeed * Time.deltaTime, Space.World);
        }
        
    }
}
