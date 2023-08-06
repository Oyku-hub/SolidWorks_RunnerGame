using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanVariables 
{

    public enum SpawnedObjects
    {
        Barrier,
        Coin,
        CollectedParticle

    };

    public enum PanelTypes
    {
        Start=0,
        Faild=1,
        Success=2,
        InGame=3
    };

    public enum PlayerAnimsTriggers
    {
        Run,
        Hit,
        Death,


    }


}
