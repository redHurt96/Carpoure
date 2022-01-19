using GameAnalyticsSDK;
using RH.Utilities.SingletonAccess;
using RoofRace.Collectables;
using RoofRace.Infrastructure;
using RoofRace.Physics;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace RoofRace
{
    public class LevelStateMachine : MonoBehaviourSingleton<LevelStateMachine>
    {
        public event Action LevelStarted;
        public event Action LevelRestarted;
        public event Action LevelFinished;
        public event Action LevelFailed;

        [SerializeField, AssetsOnly] private PlayerCar _carPrefab;
        [SerializeField] private LevelPool _levelPool;
        [SerializeField] private CameraLookPoint _cameraLookPoint;
        [SerializeField] private LevelCamera _levelCamera;
        [SerializeField] private GameObject _speedVfx;

        [Header("UI")]
        [SerializeField] private GameObject _startUi;
        [SerializeField] private GameObject _finishUi;
        [SerializeField] private GameObject _failUi;

        private Level _level;
        private PlayerCar _car;

        private Vector3 _startPoint => _level.StartPoint.position;

        private void Start()
        {
            CreateCurrentLevel();
            SwitchToStartState();
        }

        internal void StartLevel()
        {
            LevelStarted?.Invoke();

            _startUi.SetActive(false);
            _car.Enable();
            _levelCamera.EnableShaking();
            _speedVfx.SetActive(true);

            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, $"Level{_levelPool.Current}", 0f.ToString());
        }

        internal void FinishLevel()
        {
            LevelFinished?.Invoke();

            _levelCamera.RotateAround(_car.transform);
            _finishUi.SetActive(true);
            _speedVfx.SetActive(false);

            LevelTime.EnableSlowMotion();

            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Level{_levelPool.Current}", 1f.ToString());
            CollectablesMaganer.SendEvent();
        }

        internal void FailLevel()
        {
            LevelFailed?.Invoke();

            _failUi.SetActive(true);
            _speedVfx.SetActive(false);

            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Level{_levelPool.Current}", _level.CalculateProgress(_carPrefab.transform).ToString().Replace(',', '.'));
            CollectablesMaganer.SendEvent();
        }

        internal void GoToNextLevel()
        {
            CreateNextLevel();
            SwitchToStartState();
        }

        internal void RestartLevel()
        {
            LevelRestarted?.Invoke();
            CreateCurrentLevel();
            SwitchToStartState();
        }

        private void SwitchToStartState()
        {
            CreateCar();

            _cameraLookPoint.AttachTarget(_car.transform);
            _levelCamera.ResetToDefaultState();
            _speedVfx.SetActive(false);

            _startUi.SetActive(true);
            _finishUi.SetActive(false);
            _failUi.SetActive(false);

            LevelTime.ResetToDefault();
        }

        private void CreateCurrentLevel() => Create(_levelPool.GetCurrent(), ref _level, Vector3.zero);
        private void CreateNextLevel() => Create(_levelPool.GetNext(), ref _level, Vector3.zero);
        private void CreateCar() => Create(_carPrefab, ref _car, _startPoint);

        private void Create<T>(T prefab, ref T container, Vector3 atPosition) where T : Component
        {
            if (container != null)
                Destroy(container.gameObject);

            container = Instantiate(prefab, atPosition, Quaternion.identity);
        }
    }
}