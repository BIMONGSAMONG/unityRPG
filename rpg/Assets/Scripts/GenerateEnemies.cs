using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[2];

    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(MushroomEnemyDrop());
    }


    IEnumerator MushroomEnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = UnityEngine.Random.Range(5, 15);
            zPos = UnityEngine.Random.Range(11, 20);

            Instantiate(enemy[0], new Vector3(xPos, 0, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
}
