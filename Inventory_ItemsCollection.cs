using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_ItemsCollection : MonoBehaviour
{
    public void getItem()
    {
        var player = GameObject.FindWithTag("Player");

        var curInv = player.GetComponent<Inventory_Organizer>().inventory.Count;
        var maxInv = player.GetComponent<Inventory_Settings>().inventorySize;
        var fullMensage = player.GetComponent<Inventory_Settings>().inventoryFullMessage;
        var inventory = player.GetComponent<Inventory_Organizer>();

        //Verify if inventory is full
        if(!IsFull())
            inventory.AddItem(gameObject);
        else
            print(fullMensage);
    }

    private bool IsFull()
    {
        var player = GameObject.FindWithTag("Player");
        var inv = player.gameObject.GetComponent<Inventory_Organizer>();

        for(int i=0; i<inv.inventory.Count; i++)
        {
            if(inv.inventory[i]==null)
            {
                print(gameObject.name + " Foi adicionado no slot " + i);
                return false;
            }
        }
        return true;
    }
}
