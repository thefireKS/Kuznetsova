using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int quantity;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Paper,Book,Screw
    }
}