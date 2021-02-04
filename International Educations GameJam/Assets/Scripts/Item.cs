using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemType type = ItemType.Bones;
    public ItemType Type { get { return type; } }
}
