using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int id;
    public float power;
    public Texture2D icon;

    public float restore()
    {
        return power;
    }
}
