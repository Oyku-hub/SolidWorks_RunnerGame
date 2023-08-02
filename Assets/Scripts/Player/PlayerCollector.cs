using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out var collectItem))
        {
            collectItem.Collect();
            
        }
        if (other.gameObject.TryGetComponent<IObstacle>(out var obstacleItem))
        {
            obstacleItem.Hit();

        }
    }

}
