using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void Update()
    {
        StartCoroutine(MushroomEnemyDrop());
    }


    IEnumerator MushroomEnemyDrop()
    {
        while (true)
        {
            xPos = UnityEngine.Random.Range(5, 15);
            zPos = UnityEngine.Random.Range(11, 20);

            GameObject enemy = ObjectPoolingManager.instance.GetQueue();
            enemy.transform.position = new Vector3(xPos, 0, zPos);

            yield return new WaitForSeconds(1f);
        }
    }
}
