using KartGame.KartSystems;
using System;
using UnityEngine;

[RequireComponent(typeof(ArcadeKart))]
public class GroundedStateIndicator : MonoBehaviour
{
    public event Action<bool> StateChanged;
    public bool IsGrounded => _car.GroundPercent == 1f;

    private ArcadeKart _car;
    private bool _previousState;

    private void Awake()
    {
        _car = GetComponent<ArcadeKart>();
        _previousState = IsGrounded;
    }

    private void Update()
    {
        if (_previousState != IsGrounded)
            StateChanged?.Invoke(IsGrounded);

        _previousState = IsGrounded;
    }
}
