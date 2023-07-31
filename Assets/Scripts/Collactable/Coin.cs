using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] ParticleSystem collectedParticle;
    ParticleSystem coinCollectParticle;

    private void Start()
    {
        if(collectedParticle!=null)
        {
            this.coinCollectParticle = collectedParticle;
        }
    }

    #region Interface Method
    public void Collect()
    {
        coinCollectParticle.Play();
    }
    #endregion

}
