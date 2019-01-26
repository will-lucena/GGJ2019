using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MovementScript))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public Action<float> notifyHpChange;
    public Action notifyDeath;

    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private float hp;
    [SerializeField] private List<Item> inventory;
    [SerializeField] private List<Word> words;

    private MovementScript movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementScript>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Atk"))
        {
            animator.SetTrigger("toAtk");
        }
        if (Input.GetButton("Skill"))
        {
            animator.SetTrigger("toUseSkill");
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        animator.SetFloat("xSpeed", rb.velocity.x);
        animator.SetFloat("ySpeed", rb.velocity.y);
        animator.SetBool("isJumping", !movement.isGrounded);
    }

    public void receiveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            notifyDeath?.Invoke();
            animator.SetTrigger("toDeath");
        }
        else
        {
            notifyHpChange?.Invoke(-damage);
            animator.SetTrigger("toTakeDamage");
        }
    }

    public void useItem(int itemID)
    {
        Item result = inventory.Find(item => item.id == itemID);
        if (result)
        {
            float effect = result.restore();
            hp += effect;
            notifyHpChange?.Invoke(effect);
            inventory.Remove(result);
            animator.SetTrigger("toUseItem");
        }
    }
}
