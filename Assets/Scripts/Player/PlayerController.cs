using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{

    #region Fields

    Vector3 moveDirection;

    #endregion

    #region UnityFields
    [SerializeField] float forwardSpeed;
    [SerializeField] float sideSpeed;
    [SerializeField] Joystick gameJoystick;

    #endregion


    protected override void Start()
    {
        base.Start();
        isControlEnabled= true;
        isDeath= false;
        
        
    }
    //Start ve Awakeden sonra çalýsýr.
    private void FixedUpdate()
    {

        if(!isControlEnabled || isDeath)
        {
            return;
        }

        moveDirection.z= forwardSpeed*Time.fixedDeltaTime;
        moveDirection.y = 0F;
        moveDirection.x=gameJoystick.Direction.x*sideSpeed*Time.fixedDeltaTime;
        rb.AddForce(moveDirection, ForceMode.VelocityChange);

        
    }

}
