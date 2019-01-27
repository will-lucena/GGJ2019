using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIA : IA
{
    [Range(1, 3)]
    [SerializeField] private float atk;
    [SerializeField] private float launchForce;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        PlantAttackBehaviour.notifyShoot += shoot;
    }

    private void shoot()
    {
        GameObject go = Instantiate(bulletPrefab);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.launch(launchForce, launchPoint, -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("toAttack", true);
        }
    }
}
