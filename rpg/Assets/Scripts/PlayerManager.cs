using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject DieUI;

    public void KillPlayer()
    {
        DieUI.SetActive(true);
    }

    public void Revival()
    {
        Money.instance.money -= Money.instance.money / 2;
        player.GetComponent<PlayerStats>().currentHealth = player.GetComponent<PlayerStats>().maxHealth;
        player.SetActive(true);
        DieUI.SetActive(false);
    }

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DieUI.SetActive(false);
    }
}
