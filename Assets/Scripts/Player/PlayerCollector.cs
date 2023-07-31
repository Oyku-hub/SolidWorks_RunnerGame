using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

       
        if(gameObject.TryGetComponent<ICollectable>(out var collectItem))
        {
            collectItem.Collect();
        }
    }


}
