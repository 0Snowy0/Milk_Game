using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Unity tool to help with coding movement
    public CharacterController controller; 
    public float speed = 6f; 
    private Vector3 playerVelocity; 
    public bool groundedPlayer; 
    // accerleration due to gravity on Earth's surface
    public float gravity = -9.81f; 
    public float jumpHeight = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        // finds the CharacterController 
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the player is on the ground
        groundedPlayer = controller.isGrounded;

        // stops player from moving down into the ground
        if (groundedPlayer && playerVelocity.y <= 0)
        { 
            playerVelocity.y = 0f;
        }

        // gets direction the mouse is pointing toward
        // positive value means mouse is moving right/down
        // negative value means mouse is moving left/up
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // establishes direction the player should be moving based on mouse position
        Vector3 move = transform.right * x + transform.forward * z;

        // moves the player in the correct direction at a speed 
        controller.Move(move * speed * Time.deltaTime);

        //run
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = 12f;
        }
        //normal
        else
        {
            speed = 6f;
        }

        // checks if spacebar is pressed and player is on the ground
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // changes the players movement on the y axis by the set jump height
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        // adds gravity to that y axis movement
        playerVelocity.y += gravity * Time.deltaTime;

        // moves the player by the specified y value based on how the player jumps
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
