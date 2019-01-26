using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New movement", menuName = "Movement")]
public class Movement : ScriptableObject
{
    [Range(10f, 1000f)]
    public float speed;
    [Range(1f, 30f)]
    public float jumpForce;
    [Range(1, 5)]
    public int gravityDropModifier;
    public bool canDoubleJump;
    public Enums.PlayerClass type;
}
