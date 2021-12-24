using KartGame.KartSystems;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private ArcadeKart _kart;

    private void Awake() => Disable();

    public void Enable() => _kart.enabled = true;
    public void Disable() => _kart.enabled = false;
}