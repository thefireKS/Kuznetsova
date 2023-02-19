using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots;
    private List<Item> items = new List<Item>();

    private Color white = new Color(1, 1, 1, 1);
    private Color transparent = new Color(1, 1, 1, 0);

    private void OnEnable()
    {
        Container.sendToInventory += AddItemInInventory;
        InventorySlot.removeFromInventory += DeleteItemFromInventory;
    }
    private void OnDisable() 
    {
        Container.sendToInventory -= AddItemInInventory;
        InventorySlot.removeFromInventory -= DeleteItemFromInventory;
    }

    private void AddItemInInventory(Item newItem)
    {
        if(newItem == null)
            return;
        items.Add(newItem);
        for(int i=0;i<inventorySlots.Count;i++)
        {
            var img = inventorySlots[i]?.GetComponentInChildren<Transform>().Find("Image").GetComponent<Image>();
            var slot = inventorySlots[i]?.GetComponent<InventorySlot>();
            if(slot.holdingItem == null)
            {
                slot.holdingItem = newItem;
                img.color = white;
                img.sprite = newItem.icon;
                break;
            }
        }
    }

    private void DeleteItemFromInventory(Item selectedItem)
    {
        int s = items.IndexOf(selectedItem);
        var img = inventorySlots[s]?.GetComponentInChildren<Transform>().Find("Image").GetComponent<Image>();
        var slot = inventorySlots[s]?.GetComponent<InventorySlot>();
        slot.holdingItem = null;
        img.color = transparent;
        img.sprite = null;
        items[s] = null;
    }
}
