using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody) ,typeof(Animator))]
public class Player : MonoBehaviour
{
    #region Fields
    protected bool isControlEnabled;
    protected bool isDeath;
    protected Animator anim;
    protected Rigidbody rb;
    #endregion


   protected virtual void Start()
   {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }


}
