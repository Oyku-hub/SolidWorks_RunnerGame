using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Collider))]
public class BaseCollectable : MonoBehaviour, ICollectable
{
    public static event Action OnCollected;
    protected Vector3 initialScale;
    protected Collider collider;

    protected void Start()
    {
        initialScale= transform.localScale;
        collider = GetComponent<Collider>();

    }

    public virtual void Collect()
    {
      OnCollected?.Invoke();
      collider.enabled= false;
    }

    protected virtual void ResetObject()
    {

        gameObject.SetActive(false);
        this.transform.localScale = initialScale;
        collider.enabled = true;
    }
}
