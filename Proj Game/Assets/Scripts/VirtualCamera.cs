using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noiseProfile;
    private CinemachineConfiner cinemachineConfiner;
    private Player player;
    private GameObject roomBound;
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noiseProfile = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void SetCameraPosition()
    {

        //cinemachineConfiner.m_BoundingShape2D = null;
        GameObject.Find("Main Camera").GetComponent<CinemachineBrain>().enabled = false;
        Debug.Log("1111");
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        roomBound = player.GetRoomBound();
        transform.position = roomBound.transform.position;
        GameObject.Find("Main Camera").transform.position = roomBound.transform.position;
        cinemachineConfiner = virtualCamera.GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = roomBound.GetComponent<CompositeCollider2D>();
        GameObject.Find("Main Camera").GetComponent<CinemachineBrain>().enabled = true;
        virtualCamera.Follow = player.transform;

    }

    public void CameraShake(float duration = 1f, float amplitude = 2f, float frequency = 2f)
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = amplitude;
            noiseProfile.m_FrequencyGain = frequency;
            Invoke(nameof(StopShaking), duration);
        }
    }

    private void StopShaking()
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = 0f;
            noiseProfile.m_FrequencyGain = 0f;
        }
    }
}