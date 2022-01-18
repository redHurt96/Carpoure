#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class CarPath : ScriptableObject
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private List<CarState> _carStates = new List<CarState>();

        public void Add(Vector3 startPosition) => _startPosition = startPosition;
        public void Add(CarState state) => _carStates.Add(state);

        public CarState GetByTime(double time)
        {
            return null;
        }
    }

    public class InputRecorder : MonoBehaviour
    {
        private enum RecorderState
        {
            None = 0,
            Recorded,
            Saved
        }

        [SerializeField] private Transform[] _wheels;

        private RecorderState _state;
        private DateTime _startTime;

        private CarPath _asset;

        private void Awake()
        {
            CreateAsset();

            LevelStateMachine.Instance.LevelStarted += StartRecord;
            LevelStateMachine.Instance.LevelFinished += FinishRecord;
            LevelStateMachine.Instance.LevelFailed += FinishRecord;
        }

        private void FixedUpdate()
        {
            if (_state == RecorderState.Recorded)
                RecordCarState();
        }

        private void OnDestroy()
        {
            if (LevelStateMachine.IsInstanceExist)
            {
                LevelStateMachine.Instance.LevelStarted -= StartRecord;
                LevelStateMachine.Instance.LevelFinished -= FinishRecord;
                LevelStateMachine.Instance.LevelFailed -= FinishRecord;
            }
        }

        private void CreateAsset()
        {
            _asset = ScriptableObject.CreateInstance<CarPath>();
            _asset.Add(transform.position);
        }

        private void StartRecord()
        {
            _state = RecorderState.Recorded;
            _startTime = DateTime.Now;
        }

        private void RecordCarState()
        {
            _asset.Add(new CarState
            {
                Time = DateTime.Now.Subtract(_startTime).TotalMilliseconds,
                Position = transform.position,
                Rotation = transform.rotation,
                WheelsRotations = GetWheelsRotations()
            });

            Quaternion[] GetWheelsRotations()
            {
                var rotations = new Quaternion[_wheels.Length];

                for (int i = 0; i < _wheels.Length; i++)
                    rotations[i] = _wheels[i].rotation;

                return rotations;
            }
        }

        private void FinishRecord()
        {
            if (_state == RecorderState.Recorded)
            {
                _state = RecorderState.Saved;
                Save();
            }
        }

        private void Save()
        {
            AssetDatabase.CreateAsset(_asset, "Assets/_Game/BotsPaths/StatesArray.asset");
            AssetDatabase.SaveAssets();
        }
    }
}

#endif