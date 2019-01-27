using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New movement", menuName = "Movement")]
public class Movement : ScriptableObject
{
    [Range(0f, 1000f)]
    [SerializeField] private float _speed;
    [Range(0f, 30f)]
    [SerializeField] private float _jumpForce;
    [Range(0, 5)]
    [SerializeField] private int _gravityDropModifier;
    public bool canDoubleJump;
    public Enums.PlayerClass type;

    public float speed
    {
        get
        {
            return _speed;
        }
    }

    public float jumpForce
    {
        get
        {
            return _jumpForce;
        }
    }

    public float gravityDropModifier
    {
        get
        {
            return _gravityDropModifier;
        }
    }
}
