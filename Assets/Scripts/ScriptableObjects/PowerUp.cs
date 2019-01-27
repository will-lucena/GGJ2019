using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ScriptableObject
{
    public int id;
    public Enums.Powerups type;
    [Range(0, 1000f)]
    [SerializeField] protected float amount;
    public virtual float effect()
    {
        Debug.Log("Not immplemented");
        return float.NegativeInfinity;
    }
}

[CreateAssetMenu(fileName = "Max Health", menuName = "Powerups/Increase max health")]
public class IncreaseMaxHealth : PowerUp
{
    public override float effect()
    {
        return amount;
    }
}

[CreateAssetMenu(fileName = "Speed", menuName = "Powerups/Increase movement speed")]
public class IncreaseSpeed : PowerUp
{
    public override float effect()
    {
        return amount;
    }
}

[CreateAssetMenu(fileName = "Jump", menuName = "Powerups/Increase jump force")]
public class IncreaseJumpForce : PowerUp
{
    public override float effect()
    {
        return amount;
    }
}

[CreateAssetMenu(fileName = "Damage", menuName = "Powerups/Increase damage")]
public class IncreaseDamage : PowerUp
{
    public override float effect()
    {
        return amount;
    }
}

[CreateAssetMenu(fileName = "GravityScale", menuName = "Powerups/Reduce gravity scale")]
public class ReduceGravityScale : PowerUp
{
    public override float effect()
    {
        return -amount;
    }
}