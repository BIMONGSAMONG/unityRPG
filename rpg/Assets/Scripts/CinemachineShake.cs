using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    #region Singleton

    public static CinemachineShake instance;

    private void Awake()
    {
        instance = this;
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    #endregion

    CinemachineFreeLook cinemachineFreeLook;
    float shakeTimer;

    public void ShakeCamera(float internsity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = internsity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer >0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
