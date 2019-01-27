using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Word", menuName = "Item/Word")]
public class Word : ScriptableObject
{
    public int id;
    public string name;
    public PowerUp powerUp;
}
