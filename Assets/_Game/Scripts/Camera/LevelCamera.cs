using Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private CinemachineVirtualCamera _flyCamera;

    private CinemachineBasicMultiChannelPerlin _noise;

    private void Start()
    {
        SetupShaking();
        DisableShaking();
    }

    public void RotateAround(Transform target)
    {
        _flyCamera.LookAt = target;
        SetPriorityToFlyCamera();
        DisableShaking();
    }

    public void ResetToDefaultState()
    {
        SetPriorityToFollowCamera();
    }

    public void EnableShaking()
    {
        _noise.enabled = true;
    }

    private void SetupShaking()
    {
        _noise = _followCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = .3f;
    }

    private void DisableShaking() => _noise.enabled = false;

    private void SetPriorityToFlyCamera()
    {
        _followCamera.Priority = 0;
        _flyCamera.Priority = 1;
    }

    private void SetPriorityToFollowCamera()
    {
        _followCamera.Priority = 1;
        _flyCamera.Priority = 0;
    }
}