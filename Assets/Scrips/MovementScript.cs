using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 bodyOffset;
    public bool isGrounded
    {
        get
        {
            return _isGrounded;
        }
    }

    private bool _isGrounded;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Movement movement;
    [SerializeField] private string horizontalInput = "Horizontal";
    [SerializeField] private string jumpInput = "Jump";

    private float hMovement;
    private Vector3 movementVector;
    private bool doubleJumpEnabled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        doubleJumpEnabled = movement.canDoubleJump;
    }

    private void Update()
    {
        hMovement = Input.GetAxis(horizontalInput);

        if (transform.localScale.x < 0 && hMovement < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        
        if (transform.localScale.x > 0 && hMovement > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        if (Input.GetButton("Jump"))
        {
            if (_isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * movement.jumpForce, ForceMode2D.Impulse);
                doubleJumpEnabled = movement.canDoubleJump;
            }
            else
            {
                if (doubleJumpEnabled)
                {
                    doubleJumpEnabled = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * movement.jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        if (rb.velocity.y == movement.jumpForce)
        {
            rb.gravityScale = movement.gravityDropModifier;
        }

        if (rb.velocity.y == 0)
        {
            rb.gravityScale = 1;
        }
    }

    private void FixedUpdate()
    {
        hMovement *= Time.deltaTime * movement.speed;
        rb.velocity = new Vector2(hMovement, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
