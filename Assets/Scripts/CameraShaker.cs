using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : BaseObstacle
{
    [SerializeField] CinemachineVirtualCamera cmVirtualCamera;
    [SerializeField] float shakeTimeOut=.3F;

    private CinemachineBasicMultiChannelPerlin cmBasicMultiChannelPerlin;

    private void OnEnable()
    {
        cmBasicMultiChannelPerlin=cmVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (cmBasicMultiChannelPerlin == null)
        {
            Debug.Log("Errorr!!!!");
        }
        cmBasicMultiChannelPerlin.m_AmplitudeGain = 0F;
        Barrier.OnHit += Barrier_onHit;


    }

    private void OnDisable()
    {
        Barrier.OnHit -= Barrier_onHit;
    }
    private void Barrier_onHit(float obj)
    {
        StartCoroutine(ShakeCameraCoroutine());

    }
    IEnumerator ShakeCameraCoroutine()
    {

        cmBasicMultiChannelPerlin.m_AmplitudeGain = 1F;
        yield return new WaitForSeconds(shakeTimeOut);
        cmBasicMultiChannelPerlin.m_AmplitudeGain = 0F;
    }
    


}
