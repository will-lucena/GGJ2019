using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Enums.MonsterClass type;
    [Range(1, 3)]
    [SerializeField] private float atk;
    [Range(1, 5)]
    [SerializeField] private float hp;
    [SerializeField] private Word drop;

    private Movement movement;

    public void takeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            dropItem();
        }
    }
    
    private void dropItem()
    {
        Debug.Log(name + "died and drop " + drop.ToString());
    }
}
