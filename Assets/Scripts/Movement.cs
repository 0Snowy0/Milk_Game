using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Unity tool to help with coding movement
    public CharacterController controller; 
    public float speed = 12f; 
    private Vector3 playerVelocity; 
    public bool groundedPlayer; 
    // accerleration due to gravity on Earth's surface
    public float grav = -9.81f; 
    public float jumpHeight = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        // finds the CharacterController and sets it equal to our variable
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the controller is interacting with the ground
        groundedPlayer = controller.isGrounded;

        // checks if the player is on the ground and moving down. 
        // stops player from moving down into the ground
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            // the player stops moving vertically 
            playerVelocity.y = 0f;
        }

        // gets direction the mouse is pointing toward
        // positive value means mouse is moving right/down
        // negative value means mouse is moving left/up
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // establishes direction the player should be moving based on the mouse position
        // relative to the direction the player is facing
        Vector3 move = transform.right * x + transform.forward * z;

        // moves the player in the correct direction at a speed multiplied by the amount of time in between frames (Time.deltaTime)
        controller.Move(move * speed * Time.deltaTime);


        // changes the height position of the player when the space bar is pressed
        // and the player is on the ground
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // changes the players movement on the y axis by 
            // the square root of the set jump height * the direction we want it to move in * the gravity
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * grav);
        }

        // adds gravity to that y axis movement
        playerVelocity.y += grav * Time.deltaTime;

        // this moves the player by the by the specified y value based on how the player jumps
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
