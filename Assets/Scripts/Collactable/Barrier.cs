using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BaseObstacle
{
    [SerializeField] private float damage;

    protected override void Start()
    {
       this.Damage= damage;

    }
    public override void Hit()
    {
        base.Hit();
    }
}