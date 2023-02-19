using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Item holdingItem;

    public static Action<Item> removeFromInventory;

    public void removeItem()
    {
        removeFromInventory?.Invoke(holdingItem);
    }
}
