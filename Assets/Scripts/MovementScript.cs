using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementScript : MonoBehaviour
{
    public Func<List<PowerUp>> requestPowerups;

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

        spinBody();
        jump();
        manageGravityScale();
    }

    private void FixedUpdate()
    {
        hMovement *= Time.deltaTime * finalSpeed();
        rb.velocity = new Vector2(hMovement, rb.velocity.y);
    }

    private void jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (_isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * finalJumpForce(), ForceMode2D.Impulse);
            }
        }
    }

    private void manageGravityScale()
    {
        if (rb.velocity.y == movement.jumpForce)
        {
            rb.gravityScale = finalGravityScale();
        }

        if (rb.velocity.y == 0)
        {
            rb.gravityScale = 1;
        }
    }

    private void spinBody()
    {
        if (transform.localScale.x < 0 && hMovement < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        if (transform.localScale.x > 0 && hMovement > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
    }

    private float finalSpeed()
    {
        PowerUp result = requestPowerups?.Invoke().Find(powerup => powerup.type == Enums.Powerup.Speed);

        if (result)
        {
            return movement.speed + result.effect();
        }
        return movement.speed;
    }

    private float finalJumpForce()
    {
        PowerUp result = requestPowerups?.Invoke().Find(powerup => powerup.type == Enums.Powerup.JumpForce);

        if (result)
        {
            return movement.jumpForce + result.effect();
        }
        return movement.jumpForce;
    }

    private float finalGravityScale()
    {
        PowerUp result = requestPowerups?.Invoke().Find(powerup => powerup.type == Enums.Powerup.GravityScale);

        if (result)
        {
            return movement.gravityDropModifier + result.effect();
        }
        return movement.gravityDropModifier;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}
