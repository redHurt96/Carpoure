#if UNITY_EDITOR

using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class CarBot : MonoBehaviour
    {
        [SerializeField, AssetsOnly] CarPath _path;
        [SerializeField] private Transform[] _wheels;

        private bool _isRunned;
        private DateTime _startTime;

        private CarState _previous;

        private void Awake()
        {
            LevelStateMachine.Instance.LevelStarted += StartRide;
            LevelStateMachine.Instance.LevelFinished += FinishRide;
            LevelStateMachine.Instance.LevelFailed += FinishRide;
        }

        private void OnDestroy()
        {
            LevelStateMachine.Instance.LevelStarted -= StartRide;
            LevelStateMachine.Instance.LevelFinished -= FinishRide;
            LevelStateMachine.Instance.LevelFailed -= FinishRide;
        }

        private void Update()
        {
            if (_isRunned)
            {
                double time = DateTime.Now.Subtract(_startTime).TotalMilliseconds;
                CarState state = _path.GetByTime(time);

                ApplyState(state, time);
            }
        }

        private void StartRide()
        {
            _isRunned = true;
            _startTime = DateTime.Now;
        }

        private void FinishRide()
        {
            _isRunned = false;
        }

        private void ApplyState(CarState state, double time)
        {
            if (_previous != null)
            {
                float lerpValue = (float)((state.FinishTime - time) / (state.FinishTime - state.StartTime));

                transform.position = Vector3.Lerp(_previous.Position, state.Position, lerpValue);
                transform.rotation = Quaternion.Lerp(_previous.Rotation, state.Rotation, lerpValue);
            }
            else
            {
                transform.position = state.Position;
                transform.rotation = state.Rotation;
            }

            for (int i = 0; i < _wheels.Length; i++)
                _wheels[i].rotation = state.WheelsRotations[i];

            _previous = state;
        }

        #region EDITOR TOOLS

        [Button]
        private void MoveToStart() => transform.position = _path.StartPosition;
      
        #endregion
    }
}

#endif