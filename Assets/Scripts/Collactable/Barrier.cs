using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IObstacle
{
    public float Damage { get => damage; set => damage=value; }
    [SerializeField]private float damage;


    public static event Action<float> onHit;

    public void Hit()
    {
       onHit?.Invoke(damage);
    }
}
