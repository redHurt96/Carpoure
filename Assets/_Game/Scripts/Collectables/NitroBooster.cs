using KartGame.KartSystems;
using RoofRace.Logic;
using UnityEngine;

namespace RoofRace.Car
{
    [RequireComponent(typeof(ArcadeKart))]
    public class NitroBooster : MonoBehaviour
    {
        [SerializeField] private ArcadeKart.StatPowerup _powerup;

        private ArcadeKart _car;

        private void Start()
        {
            _car = GetComponent<ArcadeKart>();
            NitroManager.Instance.Enabled += EnableNitro;
        }

        private void OnDestroy()
        {
            if (NitroManager.IsInstanceExist)
                NitroManager.Instance.Enabled -= EnableNitro;
        }

        private void EnableNitro()
        {
            _powerup.MaxTime = NitroManager.Instance.MaxCount;
            _car.AddPowerup(_powerup);
        }
    }
}