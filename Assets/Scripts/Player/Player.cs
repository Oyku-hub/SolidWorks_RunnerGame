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

    private void Awake()
    {
        isControlEnabled=false; 
    }

    private void OnEnable()
    {
        GameManager.OnStartGame += GameManager_OnStartGame;
    }

    private void GameManager_OnStartGame()
    {
        GameManager.OnStartGame -= GameManager_OnStartGame;
    }

    protected virtual void Start()
   {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }


}
