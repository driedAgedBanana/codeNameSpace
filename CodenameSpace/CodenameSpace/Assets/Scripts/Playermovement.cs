using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsRemain;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemain = 2; //Start with 2 jumps
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);
    }

    /*
     * Checking if the player is grounded or not by controlling if the groundCheck circle overlap with any collider in the goundLayer.
     */
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpsRemain = 1; //Reset jump is the player touched the ground
        }

        if (Input.GetButtonDown("Jump") && jumpsRemain > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpsRemain--;
        }
    }

    /* Gizmos will draws a white sphere with the GroundCheck position as center and the groundCheckRadius
     as the radius, to visualize the ground check area
    */
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
