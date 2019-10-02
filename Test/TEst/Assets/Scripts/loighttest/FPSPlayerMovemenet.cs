using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerMovemenet : MonoBehaviour
{

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.localPosition += Vector3.right * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.A))
            transform.localPosition += Vector3.left * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.W))
            transform.localPosition += Vector3.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.S))
            transform.localPosition += Vector3.back * Time.deltaTime * speed;



        Vector3 lookAngle = transform.localEulerAngles;
        
        lookAngle.x -= Input.GetAxis("Mouse Y");
        lookAngle.y += Input.GetAxis("Mouse X");


        // Look up and Down limits

        //Stops the player from bending over backwards.
        if (lookAngle.x > 88 && lookAngle.x < 180)
        {
            transform.localEulerAngles = new Vector3(88, 0);
            
        }

        // Stops the player from bending over forwards to far.
        else if (lookAngle.x < 278 && lookAngle.x > 180)
        {
            transform.localEulerAngles = new Vector3(278, 0);
            
        }

        // If the player is just looking straight on, then just set that as the look angle.
        else
        {
            transform.localEulerAngles = new Vector3(lookAngle.x, lookAngle.y);
            
        }


    }
}