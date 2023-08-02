using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommanVariables;
public class PlayerHealth : Player
{
    [SerializeField] float maxHealth;
    float currentHealth;
    public static event Action OnPlayerDied;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        Barrier.onHit += Barrier_onHit;
  
    }

   

    private void OnDisable()
    {
        currentHealth = maxHealth;
        Barrier.onHit -= Barrier_onHit;
    
    }

   
    private void Barrier_onHit(float damage)
    {
       
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            anim.SetTrigger(PlayerAnimsTriggers.Death.ToString());
            this.isControlEnabled= false;
            this.isDeath = true;
            Debug.Log("Diedddd!!!!");
            OnPlayerDied?.Invoke();
        }
        else
        {
            anim.SetTrigger(PlayerAnimsTriggers.Hit.ToString());
        }
    }

   
    protected override void Start()
    {
        base.Start();
  
    }


}
