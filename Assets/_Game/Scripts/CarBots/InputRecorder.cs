#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class InputRecorder : MonoBehaviour
    {
        private enum State
        {
            None = 0,
            Recorded,
            Saved
        }

        [SerializeField] private MobileInput _input;

        private State _state;
        private DateTime _startTime;

        private CarStatesArray _asset;

        private void Awake()
        {
            CreateAsset();

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

        private void CreateAsset()
        {
            _asset = ScriptableObject.CreateInstance<CarStatesArray>();
            _asset.StartPosition = transform.position;
        }

        private void StartRecord()
        {
            _state = State.Recorded;
            _startTime = DateTime.Now;
        }

        private void RecordCarState() => 
            _asset.AddState(_input.HorizontalDirection, DateTime.Now.Subtract(_startTime).TotalMilliseconds);

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
            AssetDatabase.CreateAsset(_asset, "Assets/_Game/CarBots/StatesArray.asset");
            AssetDatabase.SaveAssets();
        }
    }
}

#endif