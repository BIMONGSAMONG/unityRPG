using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    int xPos;
    int zPos;

    void Update()
    {
        if ((ObjectPoolingManager.instance.monsterQueue.Count == 5))
        {
            StartCoroutine(MushroomEnemyDrop());
        }
    }

    IEnumerator MushroomEnemyDrop()
    {
        while (ObjectPoolingManager.instance.monsterQueue.Count != 0)
        {
            xPos = UnityEngine.Random.Range(5, 15);
            zPos = UnityEngine.Random.Range(11, 20);

            GameObject enemy = ObjectPoolingManager.instance.GetMQueue();
            enemy.transform.position = new Vector3(xPos, 0, zPos);

            yield return new WaitForSeconds(5.0f);
        }
    }
}
