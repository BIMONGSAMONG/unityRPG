﻿using System;
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
        while (ObjectPoolingManager.instance.m_queue.Count != 0)
        {
            xPos = UnityEngine.Random.Range(5, 15);
            zPos = UnityEngine.Random.Range(11, 20);

            GameObject enemy = ObjectPoolingManager.instance.GetQueue();
            enemy.transform.position = new Vector3(xPos, 0, zPos);
        }

        yield return new WaitForSeconds(5f);
    }
}