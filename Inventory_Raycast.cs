using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Raycast : MonoBehaviour
{

    private Inventory_ItemsCollection inventory_ItemsCollection;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        RaycastHit hit;
        var inventory_Settings = player.GetComponent<Inventory_Settings>();
        var tag = inventory_Settings.inventoryTag;
        var position = transform.position;
        var fwd = transform.forward;
        var distance = inventory_Settings.collectionDistance;
        if(Physics.Raycast(position,fwd,out hit,5))
        {
            if(hit.collider.tag == tag)
            {
                if(Input.GetKeyDown(inventory_Settings.interactiveKey))
                {
                    inventory_ItemsCollection = hit.collider.gameObject.GetComponent<Inventory_ItemsCollection>();
                    inventory_ItemsCollection.getItem();
                }
            }
        }
    }
}
