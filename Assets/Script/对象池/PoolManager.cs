using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public Stack<GameObject> pool;

    public GameObject Get()
    {
        if (pool.Count > 0)
        {
            GameObject p = pool.Pop();
            prefab.SetActive(true);
            return p;
        }

        return Instantiate(prefab);
    }

    public void Realse(GameObject p)
    {
        p.SetActive(false);
        pool.Push(p);
    }
}
