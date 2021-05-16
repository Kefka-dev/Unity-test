using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20;
    public Transform feet;
    public LayerMask groundLayers;


    float moveX;
    bool isGrounded;

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movementJump = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movementJump;
    }

    public bool IsGrounded()
    {
        Collider2D groundcheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundcheck != null)
        {
            return true;
        }

        return false;
    }
    
}