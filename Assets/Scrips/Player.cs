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
    public Action<float> notifyInventoryChange;

    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private float hp;
    [SerializeField] private List<Item> inventory;
    [SerializeField] private List<Word> words;

    #region Tests variables
    [SerializeField] private Item item;
    private float time;
    #endregion
    private MovementScript movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementScript>();
    }

    private void Start()
    {
        inventory.Add(item);
        inventory.Add(item);
        inventory.Add(item);
        notifyInventoryChange?.Invoke(inventory.Count);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("atk");
            animator.SetTrigger("toAtk");
            receiveDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("skill");
            animator.SetTrigger("toUseSkill");
            useItem(0);
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
            notifyHpChange?.Invoke(hp);
            animator.SetTrigger("toTakeDamage");
        }
    }

    public void useItem(int itemID)
    {
        Item result = inventory.FindLast(item => item.id == itemID);
        if (result)
        {
            float effect = result.restore();
            hp += effect;
            notifyHpChange?.Invoke(hp);
            inventory.Remove(result);
            animator.SetTrigger("toUseItem");
            notifyInventoryChange?.Invoke(inventory.Count);
        }
    }
}
