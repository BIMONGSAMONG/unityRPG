using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    PlayerStats playerStats;

    public ParticleSystem effect;

    private void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        effect.Stop();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        effect.Play();
    }

    public override void Die()
    {
        base.Die();

        StartCoroutine(Drop());

        ObjectPoolingManager.instance.InsertMQueue(gameObject);
        
        if (playerStats.quest.isActive)
        {
            QuestActive();
        }

    }

    void QuestActive()
    {
        if (playerStats.quest.goal.IsReached())
         {

         }
         else
         {
            playerStats.quest.goal.EnmeyKilled();
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
