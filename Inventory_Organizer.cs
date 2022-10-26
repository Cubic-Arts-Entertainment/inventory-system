using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Organizer : MonoBehaviour
{

    public List<GameObject> inventory;
    public GameObject currentyItem;
    public GameObject hand;
    public int handing=0;

    private void Update()
    {
        //Função para fazer os items que não estejam na mão do personagem desaparecer 
        //Precisa ser atualizada na próxima versão
        foreach(GameObject items in inventory)
            if(items!=null)
                if(items==inventory[handing])
                    inventory[handing].gameObject.SetActive(true);
                else
                    items.SetActive(false);

        //Valida se o personagem está com algo na mão 
        if(inventory[handing]!=null)
            inventory[handing] = inventory[handing];
        else
            inventory[handing] = null;

        // Input para dropar o item que está segurando
        if(Input.GetKeyDown("g"))
            RemoveItem(handing);

        // Inputs para selecionar os items do inventário
        if(Input.GetKeyDown(KeyCode.Alpha1))
            SwitchItem(0);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            SwitchItem(1);
        if(Input.GetKeyDown(KeyCode.Alpha3))
            SwitchItem(2);
        if(Input.GetKeyDown(KeyCode.Alpha4))
            SwitchItem(3);
        if(Input.GetKeyDown(KeyCode.Alpha5))
            SwitchItem(4);

        MoveItem();
    }

    private void Start()
    {  
        var set = gameObject.GetComponent<Inventory_Settings>();
        for(int i=0; i<set.inventorySize; i++)
        {
            inventory.Add(null);
        }
    }

    public void AddItem(GameObject GO)
    {
        for(int i=0; i<inventory.Count; i++)
        {
            if(inventory[i]==null)
            {
                inventory[i] = GO;                  
                break;
            }
        }
    }

    private void RemoveItem(int selectedItem)
    {
        if(inventory[handing]!=null)
        {
            inventory[handing].GetComponent<Collider>().enabled = true;
            inventory[handing].transform.SetParent(null);
            inventory[handing] = null;
        }
        else
        {
            print("Você não está segurando nada na mão.");
        }
    }

    private void MoveItem()
    {
        if(inventory[handing]!=null)
        {
            if(inventory[handing].transform.position != hand.transform.position)
                inventory[handing].transform.position = hand.transform.position;
            inventory[handing].transform.SetParent(hand.transform);
            inventory[handing].GetComponent<Collider>().enabled = false;
        }
    }

    private bool IsholdingNone()
    {
        if(inventory[handing]==null)
            return true;
        else
            return false;
    }

    private bool IsInventoryNone(int listItems)
    {
        if(listItems > 0)
            return false;
        else
            return true;
    }

    private void FirstItemAnimation()
    {
        var anim = hand.GetComponent<Animator>();

        anim.Play("Back");
    }

    private void SwitchItemAnimation()
    {
        var anim = hand.GetComponent<Animator>();

        anim.SetTrigger("Switch");
    }

    private void SwitchItem(int slot)
    {
        handing=slot;
        if(inventory[handing]==null)
            FirstItemAnimation();
        else
            SwitchItemAnimation();
    }
}
