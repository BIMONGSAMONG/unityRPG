using UnityEngine;

public class ItemPIckUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {

        Debug.Log("pick up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        Destroy(gameObject);
    }
}
