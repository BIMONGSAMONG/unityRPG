using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Money instance;

    public Text moneyCount;

    public int money = 0;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCount.text = money.ToString();
    }
}
