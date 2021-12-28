#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class TrailRecorder : MonoBehaviour
    {
        private enum State
        {
            None = 0,
            Recorded,
            Saved
        }

        [SerializeField] private Transform _car;
        [SerializeField] private Transform[] _wheels;

        private State _state;
        private List<CarState> _carStates;
        private DateTime _startTime;

        private void Awake()
        {
            LevelStateMachine.Instance.LevelStarted += StartRecord;
            LevelStateMachine.Instance.LevelFinished += FinishRecord;
            LevelStateMachine.Instance.LevelFailed += FinishRecord;
        }

        private void Update()
        {
            if (_state == State.Recorded)
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

        private void StartRecord()
        {
            _state = State.Recorded;
            _carStates = new List<CarState>();
            _startTime = DateTime.Now;
        }

        private void RecordCarState()
        {
            var state = new CarState
            {
                Position = _car.position,
                Rotation = _car.rotation,
                WheelsRotation = _wheels
                    .Select(x => x.rotation)
                    .ToArray(),
                TimeSinceStart = DateTime.Now.Subtract(_startTime).TotalMilliseconds
            };

            _carStates.Add(state);
        }

        private void FinishRecord()
        {
            if (_state == State.Recorded)
            {
                _state = State.Saved;
                Save();
            }
        }

        private void Save()
        {
            var asset = ScriptableObject.CreateInstance<CarStatesArray>();
            asset.SetStates(_carStates.ToArray());

            AssetDatabase.CreateAsset(asset, "Assets/_Game/CarBots/StatesArray.asset");
            AssetDatabase.SaveAssets();
        }
    }
}

#endif