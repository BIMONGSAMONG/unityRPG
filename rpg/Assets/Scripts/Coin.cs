using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float activeTime = 10.0f;

    void OnEnable()
    {
        StartCoroutine(SetActivefalse(gameObject, activeTime));
    }

    IEnumerator SetActivefalse(GameObject gameObject, float second)
    {
        yield return new WaitForSeconds(second);
        ObjectPoolingManager.instance.InsertCQueue(gameObject);
    }
}
