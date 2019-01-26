using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New movement", menuName = "Movement")]
public class Movement : ScriptableObject
{
    [Range(0f, 1000f)]
    public float speed;
    [Range(0f, 30f)]
    public float jumpForce;
    [Range(0, 5)]
    public int gravityDropModifier;
    public bool canDoubleJump;
    public Enums.PlayerClass type;
}
