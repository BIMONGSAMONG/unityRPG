using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject statsUI;
    public Text maxHealth;
    public Text atk;
    public Text def;
    public Text hCost;
    public Text aCost;
    public Text dCost;
    public Button hbutton;
    public Button abutton;
    public Button dbutton;

    int healthCost = 50;
    int atkCost = 10;
    int defCost = 10;

    public delegate void OnStatsChangedCallback();
    public OnStatsChangedCallback onStatsChangedCallback;


    private void Start()
    {
        onStatsChangedCallback += UpdateUI;
        onStatsChangedCallback.Invoke();
    }

    void Update()
    {
        if (Input.GetButtonDown("Stats"))
        {
            OnOff();
        }

        if (statsUI.activeSelf)
        {
            ButtonActive(hbutton, healthCost);
            ButtonActive(abutton, atkCost);
            ButtonActive(dbutton, defCost);
        }
    }

    public void OnOff()
    {
        statsUI.SetActive(!statsUI.activeSelf);
    }

    void UpdateUI()
    {
        maxHealth.text = playerStats.maxHealth.ToString();
        atk.text = playerStats.damage.GetValue().ToString();
        def.text = playerStats.armor.GetValue().ToString();

        hCost.text = healthCost.ToString();
        aCost.text = atkCost.ToString();
        dCost.text = defCost.ToString();
    }

    void ButtonActive(Button button, int cost)
    {
        if (Money.instance.money < cost)
        {
            button.interactable = false;
            button.image.color = Color.white;
        }
        else
        {
            if (button.interactable == false)
            {
                button.interactable = true;
                button.image.color = Color.green;
            }
        }
    }

    public void HealthUp()
    {
        Money.instance.moneyChanged(-healthCost);
        playerStats.maxHealth += 10;

        if(onStatsChangedCallback != null)
            onStatsChangedCallback.Invoke();
    }
    public void AtkhUp()
    {
        Money.instance.moneyChanged(-atkCost);
        playerStats.damage.baseValue++;

        if (onStatsChangedCallback != null)
            onStatsChangedCallback.Invoke();
    }
    public void DefthUp()
    {
        Money.instance.moneyChanged(-defCost);
        playerStats.damage.baseValue++;

        if (onStatsChangedCallback != null)
            onStatsChangedCallback.Invoke();
    }
}
