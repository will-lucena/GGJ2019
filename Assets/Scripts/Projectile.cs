using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Monster script = collision.gameObject.GetComponent<Monster>();
            script.takeDamage(1);
        }
        Destroy(gameObject);
    }

    public void launch(float force, Transform spawn, float direction)
    {
        transform.position = spawn.position;
        transform.rotation = spawn.rotation;
        rb.AddForce(Vector2.right * direction * force, ForceMode2D.Force);
        Invoke("turnOff", 4f);
    }

    private void turnOff()
    {
        rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
}
