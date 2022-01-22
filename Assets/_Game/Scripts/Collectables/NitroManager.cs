using RH.Utilities.SingletonAccess;
using System;
using System.Collections;
using UnityEngine;

namespace RoofRace.Collectables
{
    public class NitroManager : MonoBehaviourSingleton<NitroManager>
    {
        public event Action Enabled;
        public event Action Disabled;
        public event Action CountChanged;

        public int Count { get; private set; }
        public int MaxCount => _enableCount;

        [SerializeField] private int _enableCount = 20;
        [SerializeField] private float _activeTime = 3f;

        private void Start() => CollectablesMaganer.Instance.CountChanged += AddNitro;
        private void OnDestroy() => CollectablesMaganer.Instance.CountChanged -= AddNitro;

        public void Enable() => StartCoroutine(NitroBoost());

        private void AddNitro()
        {
            Count++;
            CountChanged?.Invoke();
        }

        private IEnumerator NitroBoost()
        {
            Enabled?.Invoke();

            yield return new WaitForSeconds(_activeTime);

            Disabled?.Invoke();
        }
    }
}