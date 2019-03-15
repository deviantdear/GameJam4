using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
        
    }

    void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        //Add item to inventory or update UI, XP etc.
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
