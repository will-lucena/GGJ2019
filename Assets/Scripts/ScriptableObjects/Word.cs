using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New word", menuName = "Item/Word")]
public class Word : ScriptableObject
{
    public int id;
    public PowerUp powerUp;
}
