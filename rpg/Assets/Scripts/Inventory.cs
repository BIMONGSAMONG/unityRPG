using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> Items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefautItem)
        {
            if (!item.isDefautItem)
            {
                if(Items.Count >= space)
                {
                    Debug.Log("Not enought room.");
                    return false;
                }
            }
            Items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove (Item item)
    {
        Items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
