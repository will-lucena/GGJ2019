using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class IA : MonoBehaviour
{
    [HideInInspector] public float speed;
    protected Rigidbody2D rb;
    protected Animator animator;
}
