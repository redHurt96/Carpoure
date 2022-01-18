#if UNITY_EDITOR

using Sirenix.OdinInspector;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RoofRace.Bots
{
    public class CarStateRecorder : MonoBehaviour
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

        private void Update()
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
            var state = new CarState
            {
                Position = transform.position,
                Rotation = transform.rotation,
                WheelsRotations = GetWheelsRotations(),
            };

            _asset.Add(state, (float)DateTime.Now.Subtract(_startTime).TotalMilliseconds);

            Quaternion[] GetWheelsRotations()
            {
                var rotations = new Quaternion[_wheels.Length];

                for (int i = 0; i < _wheels.Length; i++)
                    rotations[i] = _wheels[i].rotation;

                return rotations;
            }
        }

        [Button]
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
            string path = "Assets/_Game/BotsPaths";
            int pathsCount = Directory.GetFiles(path).Length;

            AssetDatabase.CreateAsset(_asset, $"{path}/Path{pathsCount}.asset");
            AssetDatabase.SaveAssets();
        }
    }
}

#endif