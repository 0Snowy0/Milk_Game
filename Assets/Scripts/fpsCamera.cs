using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCamera : MonoBehaviour
{
    // sensitivity of mouse
    public float sensitivity = 100f;

    // reference to the actual player object to move the whole player
    public Transform playerBody;

    // the value the player moves around the x axis
    float yRot = 0f;

    private bool showCursor = false;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        // locks the cursor to the center of the screen 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //locks and unlocks cursor when F is pressed
        if (Input.GetKeyDown(KeyCode.F) && !showCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            showCursor = true;
            Cursor.visible = showCursor;
            isActive = false;
        }

        else if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.Locked;
            showCursor = false;
            Cursor.visible = showCursor;
            isActive = true;
        }

        if (!isActive)
            return;

        // finds the mouse position relative to the sensitivity and frame rate
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // decreases yRot based on the mouse's y position
        yRot -= mouseY;

        // restricts player camera 
        yRot = Mathf.Clamp(yRot, -90f, 90f);

        // rotates the player around the z axis based on the mouse's y position
        transform.localRotation = Quaternion.Euler(yRot, 0f, 0f);

        // rotates the player around the y axis based on the mouse's x position
        playerBody.Rotate(Vector3.up * mouseX);

    }
}


