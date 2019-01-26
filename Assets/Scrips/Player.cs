using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MovementScript))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
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
        HitBehaviour.updateHitBehaviourState += hitBehaviour;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!animator.GetBool("isAttacking"))
            {
                animator.SetTrigger("toAtk");
            }
            //receiveDamage(1);
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
        animator.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
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

    private void hitBehaviour(bool state)
    {
        animator.SetBool("isAttacking", state);
    }

    private void receiveWord(Word drop)
    {
        Word result = words.Find(word => word.id == drop.id);
        if (!result)
        {
            words.Add(drop);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("isAttacking"))
        {
            Monster script = collision.gameObject.GetComponent<Monster>();
            script.dropWord += receiveWord;
            script.takeDamage(1);
        }
    }

}
