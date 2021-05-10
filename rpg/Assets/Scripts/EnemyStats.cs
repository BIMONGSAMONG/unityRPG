using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Die()
    {
        base.Die();

        ObjectPoolingManager.instance.InsertQueue(gameObject);
        currentHealth = maxHealth;

        player.GetComponent<PlayerController>().focus = null;

        if (player.GetComponent<PlayerStats>().quest.isActive)
        {      
            if (player.GetComponent<PlayerStats>().quest.goal.IsReached())
            {

            }
            else
            {
                player.GetComponent<PlayerStats>().quest.goal.EnmeyKilled();
            }
        }
    }
}
