using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject m_prefab;
    public GameObject coinPrefab;

    public Queue<GameObject> m_queue = new Queue<GameObject>();
    public Queue<GameObject> coinQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for (int i = 0; i < 5; i++)
        {
            GameObject monsterObject = Instantiate(m_prefab, Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(monsterObject);
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
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetMQueue()
    {
        GameObject t_object = m_queue.Dequeue();
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
