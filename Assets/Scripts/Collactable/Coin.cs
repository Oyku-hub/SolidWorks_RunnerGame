using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour,ICollectable
{
    Vector3 initialScale;
    #region Interface Method
    Collider collider;
    private void Start()
    {
        initialScale = this.transform.localScale;
        collider = GetComponent<Collider>();
      
    }
    public void Collect()
    {

        collider.enabled = false;
        Destroy(this.GetComponent<Collider>());

        this.transform.DOScale(Vector3.zero, 0.3F).OnComplete(() =>
        {
            CreateGameObjectsPool.Instance.CreateGameObject(CommanVariables.SpawnedObjects.CollectedParticle.ToString(), this.transform.position, null);
            ResetObject();
        });

    }
    #endregion

   void ResetObject()
    {
        gameObject.SetActive(false);
        this.transform.localScale=initialScale;
        collider.enabled = true;
    }
}
