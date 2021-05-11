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

        StartCoroutine(Drop());

        ObjectPoolingManager.instance.InsertMQueue(gameObject);
        currentHealth = maxHealth;
        
        if (player.GetComponent<PlayerStats>().quest.isActive)
        {
            QuestActive();
        }

    }

    void QuestActive()
    {
        if (player.GetComponent<PlayerStats>().quest.goal.IsReached())
         {

         }
         else
         {
             player.GetComponent<PlayerStats>().quest.goal.EnmeyKilled();
         }
    }

    IEnumerator Drop()
    {
        int dropCount = Random.Range(1, 5);

        for (int i = 0; i < dropCount; i++)
        {
            GameObject coin = ObjectPoolingManager.instance.GetCQueue();
            coin.transform.position = gameObject.transform.position;
        }

        yield return new WaitForSeconds(0.3f);
    }
}
