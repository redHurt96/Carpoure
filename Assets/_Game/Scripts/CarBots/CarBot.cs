using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace RoofRace.Bots
{
    public class CarBot : MonoBehaviour
    {
        [SerializeField, AssetsOnly] CarPath _path;
        [SerializeField] private Transform[] _wheels;

        private bool _isRunned;
        private DateTime _startTime;


        private void Awake()
        {
            LevelStateMachine.Instance.LevelStarted += StartRide;
            LevelStateMachine.Instance.LevelFinished += FinishRide;
            LevelStateMachine.Instance.LevelFailed += FinishRide;
        }

        private void OnDestroy()
        {
            if (!LevelStateMachine.IsInstanceExist)
                return;

            LevelStateMachine.Instance.LevelStarted -= StartRide;
            LevelStateMachine.Instance.LevelFinished -= FinishRide;
            LevelStateMachine.Instance.LevelFailed -= FinishRide;
        }

        private void Update()
        {
            if (_isRunned)
            {
                float time = (float)DateTime.Now.Subtract(_startTime).TotalMilliseconds;
                CarState state = _path.GetByTime(time);

                ApplyState(state);
            }
        }

        private void ApplyState(CarState state)
        {
            transform.SetPositionAndRotation(state.Position, state.Rotation);

            for (int i = 0; i < _wheels.Length; i++)
                _wheels[i].rotation = state.WheelsRotations[i];
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

        #region EDITOR TOOLS

        [Button]
        private void MoveToStart() => transform.position = _path.StartPosition;
      
        #endregion
    }
}