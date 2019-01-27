using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum PlayerClasses
    {
        Knight,
        Rogue,
        Paladin,
        Npc
    }

    public enum MonsterClasses
    {
        Fly,
        Boss,
        Regular,
        Shooter
    }

    public enum Powerups
    {
        MaxHealth,
        Speed,
        JumpForce,
        Damage,
        GravityScale
    }

    public enum Checkpoints
    {
        HorizontalMovement,
        Jump,
        Hit,
        Spell,
        CatchItem,
        UseItem,
        NextLevel
    }
}
