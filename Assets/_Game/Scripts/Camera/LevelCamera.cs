using Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private CinemachineVirtualCamera _flyCamera;

    public void RotateAround(Transform target)
    {
        _flyCamera.LookAt = target;
        SetPriorityToFlyCamera();
    }

    public void ResetToDefaultState()
    {
        SetPriorityToFollowCamera();
    }

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