using RH.Utilities.SingletonAccess;
using RoofRace.Collectables;
using System;
using System.Collections;
using UnityEngine;

namespace RoofRace.Logic
{
    public class NitroManager : MonoBehaviourSingleton<NitroManager>
    {
        public event Action Enabled;
        public event Action CountChanged;

        public int Count { get; private set; }
        public int MaxCount => _enableCount;
        public float ActiveTime => _activeTime;

        [SerializeField] private int _enableCount = 20;
        [SerializeField] private float _activeTime = 3f;

        private void Start() => CollectablesMaganer.Instance.CountChanged += AddNitro;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                Enable();
        }

        private void OnDestroy() => CollectablesMaganer.Instance.CountChanged -= AddNitro;

        private void Enable() => Enabled?.Invoke();

        private void AddNitro()
        {
            Count++;
            CountChanged?.Invoke();
        }
    }
}