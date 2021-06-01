using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    #region Singleton

    public static ObjectPoolingManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public GameObject monsterPrefab;
    public GameObject coinPrefab;

    public Queue<GameObject> monsterQueue = new Queue<GameObject>();
    public Queue<GameObject> coinQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for (int i = 0; i < 5; i++)
        {
            GameObject monsterObject = Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity);
            monsterQueue.Enqueue(monsterObject);
            monsterObject.SetActive(false);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject coinObject = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
            coinQueue.Enqueue(coinObject);
            coinObject.SetActive(false);
        }
        
    }

    public void InsertMQueue(GameObject p_object)
    {
        monsterQueue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetMQueue()
    {
        GameObject t_object = monsterQueue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }

    public void InsertCQueue(GameObject p_object)
    {
        coinQueue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetCQueue()
    {
        GameObject t_object = coinQueue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
