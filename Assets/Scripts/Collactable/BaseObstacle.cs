using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObstacle : MonoBehaviour, IObstacle
{
    
    public float Damage { get; set; }

    public static event Action<float> OnHit;

    protected  virtual void Start()
    {
        
    }
    public virtual void Hit()
    {
        OnHit?.Invoke(Damage);
    }

  
}
