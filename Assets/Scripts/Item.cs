using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Health Potion", menuName = "Item/Health Potion")]
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
