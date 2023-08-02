using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    abstract float Damage { get; set; }
    void Hit();

}
    
