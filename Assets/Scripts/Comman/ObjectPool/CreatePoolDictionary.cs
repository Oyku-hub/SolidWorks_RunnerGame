
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreatePoolDictionary : MonoBehaviour
{
    private List<Pool> pool;
    public Dictionary<string, Queue<GameObject>> poolDictionary { get; set; }

    public void ResetPool()
    {
        this.pool = new List<Pool>();
    }
    public void SetPool(List<Pool> pool,Transform parent=null) {
        this.pool = pool;
        poolDictionary=new Dictionary<string, Queue<GameObject>>();
        foreach (Pool item in pool)
        {
            Queue<GameObject>objectPool=new Queue<GameObject>();
            for(int i=0;i<item.Size;i++)
            {
                GameObject gmObject = Instantiate(item.Prefab);
                gmObject.name=item.Prefab.name;
                gmObject.SetActive(false);

                if (parent != null)
                {
                    gmObject.transform.SetParent(parent);
                }

                objectPool.Enqueue(gmObject);
            }

            poolDictionary.Add(item.Name, objectPool);  
        }
    }


    public GameObject SpawnFromPool(string name, Vector3 position, Transform parent = null)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.Log("null Error");
            return null;
        }

        GameObject spawnObject = poolDictionary[name].Dequeue();
        spawnObject.SetActive(true);
        if(parent!=null)
        {
            spawnObject.transform.SetParent(parent);
        }
        spawnObject.transform.position = position;
        spawnObject.transform.rotation=Quaternion.identity;
        poolDictionary[name].Enqueue(spawnObject); //nextItem
        return spawnObject;


    }

}
