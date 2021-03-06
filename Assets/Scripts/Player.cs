﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MovementScript))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHittable
{
    public Action<float> notifyHpChange;
    public Action notifyDeath;
    public Action<float> notifyInventoryChange;
    public Action<string> notifyCheckpoint;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isIvunerable = false;

    [SerializeField] private float hp;
    [SerializeField] private List<Item> inventory;
    [SerializeField] private List<Word> words;
    [SerializeField] private GameObject projectileGO;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float launchForce;

    private MovementScript movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementScript>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        notifyInventoryChange?.Invoke(inventory.Count);
        PaladinHitBehaviour.updateHitBehaviourState += hitBehaviour;
        SpellBehaviour.throwSpell += launchSpell;
        movement.requestPowerups += powerups;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!animator.GetBool("isAttacking"))
            {
                animator.SetTrigger("toAtk");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("toUseSkill");
        }
    }

    private void LateUpdate()
    {
        animator.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("ySpeed", rb.velocity.y);
        animator.SetBool("isJumping", !movement.isGrounded);
    }

    public void receiveDamage(float damage)
    {
        if (!isIvunerable)
        {
            hp -= damage;
            if (hp <= 0)
            {
                notifyDeath?.Invoke();
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu 1");
            }
            else
            {
                notifyHpChange?.Invoke(hp);
                animator.SetTrigger("toTakeDamage");
                StartCoroutine(becomeIvunerable());
            }
        }
    }

    private IEnumerator becomeIvunerable()
    {
        isIvunerable = true;
        Color32 initialColor = sprite.color;
        sprite.color = new Color32(255, 127, 127, 255);
        yield return new WaitForSeconds(1.3f);
        sprite.color = initialColor;
        isIvunerable = false;
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

    private void launchSpell()
    {
        GameObject go = Instantiate(projectileGO);
        Projectile script = go.GetComponent<Projectile>();
        script.launch(launchForce, launchPoint, -Mathf.Sign(transform.localScale.x));
    }

    private void receiveWord(Word drop)
    {
        Word result = words.Find(word => word.id == drop.id);
        if (!result)
        {
            words.Add(drop);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            notifyCheckpoint?.Invoke(collision.gameObject.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("isAttacking"))
        {
            IHittable script = collision.gameObject.GetComponent<IHittable>();
            script.receiveDamage(1);
        }
    }

    private List<PowerUp> powerups()
    {
        List<PowerUp> result = new List<PowerUp>();

        foreach (Word word in words)
        {
            result.Add(word.powerUp);
        }

        return result;
    }
}
