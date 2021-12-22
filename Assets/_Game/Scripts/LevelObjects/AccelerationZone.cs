using KartGame.KartSystems;
using UnityEngine;

public class AccelerationZone : MonoBehaviour
{
    [SerializeField] private ArcadeKart.StatPowerup _powerup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarCollider>(out var carCollider))
            carCollider.Kart.AddPowerup(_powerup);
    }
}
