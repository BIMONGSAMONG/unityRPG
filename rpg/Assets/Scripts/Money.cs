using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    #region Singleton

    public static Money instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public Text moneyCount;

    public int money = 0;

    public delegate void MoneyChanged(int moneyAmount); 
    public MoneyChanged moneyChanged;

    void Start()
    {
        moneyChanged += UIUpdate;
        moneyChanged.Invoke(money);
    }

    void UIUpdate(int moneyAmount)
    {
        money += moneyAmount;
        moneyCount.text = money.ToString();
    }
}
