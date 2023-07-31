using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CommanVariables;

public class BarrierSpawner : MonoBehaviour
{

    #region Unity Fields
    [SerializeField] Transform[] spawnPoints;
    [Header("Keeping minimum and maximum timeout between spawns")]
    [SerializeField] float minTimeout;
    [SerializeField] float maxTimeout;
    [SerializeField] PlayerController player;
    [SerializeField] float pointZOffset;
    [Range(0f, 1f)]
    [SerializeField] float coinPercent;


    #endregion

    #region Fields
    Vector3 pos=Vector3.zero;
    #endregion

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
    private void Update()
    {

        pos=transform.position;
        pos.z = player.transform.position.z+pointZOffset;
        this.transform.position = pos;  

    }

    IEnumerator SpawnCoroutine()
    {

        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeout, maxTimeout));
            var result = Random.Range(0F, 1F);
            if(result>coinPercent)
            {
                CreateGameObject(SpawnedObjects.Barrier);
            }
            else
            {
                CreateGameObject(SpawnedObjects.Coin);
                
            }
     
        }
    }


    void CreateGameObject(SpawnedObjects spawnedObjects)
    {

        CreateGameObjectsPool.Instance.CreateGameObject(spawnedObjects.ToString(), spawnPoints[Random.Range(0, spawnPoints.Length)].position, null);


    }
}
