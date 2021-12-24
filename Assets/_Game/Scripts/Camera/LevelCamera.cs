using Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private CinemachineVirtualCamera _flyCamera;

    public void RotateAround(Transform target)
    {
        _flyCamera.LookAt = target;
    }
}
