using KartGame.KartSystems;
using RoofRace.Logic;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    [RequireComponent(typeof(Collider))]
    public class AccelerationZone : MonoBehaviour
    {
        [SerializeField] private ArcadeKart.StatPowerup _powerup;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider) && !NitroManager.Instance.IsEnabled)
                carCollider.Kart.AddPowerup(_powerup);
        }
    }
}