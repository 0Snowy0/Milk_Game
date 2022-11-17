using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCamera : MonoBehaviour
{
    // sensitivity of mouse
    public float sensitivity = 100f;

    // reference to the actual player object to move the whole player
    public Transform playerBody;

    // the value  the player moves around the x axis
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // locks the cursor to the center of the screen 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        // finds the mouse position relative to the sensitivity and frame rate
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // decreases xRotation based on the mouse's y position
        xRotation -= mouseY;
        
        // restricts player camera to a range to keep player from looking all the way behind
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotates the player around the x axis based on the mouse's y position
        // after our clamp
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // rotates the player around the y axis based on the mouse's x position
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
