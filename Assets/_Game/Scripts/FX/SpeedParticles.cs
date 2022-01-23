using RoofRace.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.FX
{
    public class SpeedParticles : MonoBehaviour
    {
        [SerializeField] private int _defaultRate = 20;
        [SerializeField] private int _nitroRate = 200;

        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();

            NitroManager.Instance.Enabled += Increase;
            NitroManager.Instance.Disabled += Decrease;
        }

        private void OnDestroy()
        {
            if (NitroManager.IsInstanceExist)
            {
                NitroManager.Instance.Enabled += Increase;
                NitroManager.Instance.Disabled += Decrease;
            }
        }

        private void Increase()
        {
            ParticleSystem.EmissionModule emission = _particleSystem.emission;
            emission.rateOverTime = _nitroRate;
        }

        private void Decrease()
        {
            ParticleSystem.EmissionModule emission = _particleSystem.emission;
            emission.rateOverTime = _defaultRate;
        }
    }
}