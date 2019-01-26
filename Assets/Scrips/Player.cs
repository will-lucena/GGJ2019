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

    [SerializeField] private float hp;
    [SerializeField] private List<Item> inventory;
    [SerializeField] private List<Word> words;

    private MovementScript movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementScript>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("fire");
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void receiveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            notifyDeath?.Invoke();
        }
        else
        {
            notifyHpChange?.Invoke(-damage);
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
        }
    }
}
