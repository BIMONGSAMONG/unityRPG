using UnityEngine;

public enum itemType
{
    Wear, Coin
}

public class ItemPIckUp : Interactable
{
    public itemType itemType;
    public Item item;

    public override void Interact()
    {
        base.Interact();

        switch(itemType)
        {
            case itemType.Wear:
                ItemPickUp();
                break;
            case itemType.Coin:
                CoinPickUp();
                break;
        }  
    }

    void ItemPickUp()
    {
        Debug.Log("pick up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        Destroy(gameObject);
    }

    void CoinPickUp()
    {
        Money.instance.money += 10;
        ObjectPoolingManager.instance.InsertCQueue(gameObject);
    }
}
