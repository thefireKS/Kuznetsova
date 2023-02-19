using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private GameObject lootMessage;
    public Item containedItem;

    public string message;

    public static Action <string> changeMessage;
    public static Action<Item> sendToInventory;
    private void Start()
    {
        ChangeMessage();
    }
    private void ChangeMessage()
    {
        if (containedItem == null)
            message = "Ничего нет";
        else
            message = containedItem.itemName;
    }
    private void OnMouseDown()
    {
        var msgCanvas = Instantiate(lootMessage, transform.position, Quaternion.identity);
        msgCanvas.GetComponent<MessageSender>().messageText.text = message;
        sendToInventory?.Invoke(containedItem);
        containedItem = null;
        ChangeMessage();
    }
}