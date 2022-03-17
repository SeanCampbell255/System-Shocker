using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f; //adjustable sensitivity

    public Transform playerBody; //player's model/transform

    float xRotation = 0f; //updated by mouse movement, updates player rotation

    void Start()
    {
        //keeps cursor in game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //set axis rotation direction & magnitude relative to frame time
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //set and clamp xRotation based on mouse y-axis movement;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamp so can't speeeeen

        //updates the player with rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
