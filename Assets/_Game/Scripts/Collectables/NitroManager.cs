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
        public event Action Disabled;
        public event Action CountChanged;

        public float Count { get; private set; }
        public int MaxCount => _enableCount;
        public float ActiveTime => _activeTime;
        public bool IsEnabled { get; private set; }

        [SerializeField] private int _enableCount = 20;
        [SerializeField] private float _activeTime = 3f;

        private void Start()
        {
            CollectablesMaganer.Instance.CountChanged += AddNitro;
            LevelStateMachine.Instance.LevelStarted += SetToZero;

            SetToZero();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N) && Count >= MaxCount)
                Enable();
        }

        private void OnDestroy()
        {
            if (CollectablesMaganer.IsInstanceExist)
                CollectablesMaganer.Instance.CountChanged -= AddNitro;

            if (LevelStateMachine.IsInstanceExist)
                LevelStateMachine.Instance.LevelStarted -= SetToZero;
        }

        public void Enable() => StartCoroutine(PerformNitro());

        private void SetToZero() => ChangeCount(0);

        private IEnumerator PerformNitro()
        {
            Enabled?.Invoke();

            IsEnabled = true;
            float time = 0f;

            while (time < ActiveTime)
            {
                ChangeCount(Count - Time.deltaTime * MaxCount);
                time += Time.deltaTime;

                yield return null;
            }

            ChangeCount(0);
            IsEnabled = false;

            Disabled?.Invoke();
        }

        private void AddNitro()
        {
            if (!IsEnabled && Count < MaxCount)
                ChangeCount(Count + 1);
        }

        private void ChangeCount(float to)
        {
            Count = to;
            CountChanged?.Invoke();
        }
    }
}