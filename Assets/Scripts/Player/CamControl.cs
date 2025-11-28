using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/*  Keys:
	arrows	- movement
	hold shift		- enable fast movement mode
	hold alt  	- enable free look
*/    

public class FreeCam : MonoBehaviour
{
   
    public float movementSpeed = 10f;

 
    public float freeLookSensitivity = 3f;


    private bool looking = false;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }


        if (looking)
        {
            float newRotationX = Input.GetAxis("Horizontal") * freeLookSensitivity;
            float newRotationY = Input.GetAxis("Vertical") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }
 

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    
    public void StartLooking()
    {
        looking = true;
       
    }

    
    public void StopLooking()
    {
        looking = false;
        
    }
}