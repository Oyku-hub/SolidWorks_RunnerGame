using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System;
using UnityEngine;

public class Coin : BaseCollectable 
{

    public override  void Collect()
    {
        base.Collect();

        this.transform.DOScale(Vector3.zero, 0.3F).OnComplete(() =>
        {
            CreateGameObjectsPool.Instance.CreateGameObject(CommanVariables.SpawnedObjects.CollectedParticle.ToString(), this.transform.position, null);
            ResetObject();
        });


    }
  

  
}
