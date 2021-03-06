﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] string target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(target))
        {
            IHittable script = collision.gameObject.GetComponent<IHittable>();
            script.receiveDamage(1);
            Destroy(gameObject);
        }
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
