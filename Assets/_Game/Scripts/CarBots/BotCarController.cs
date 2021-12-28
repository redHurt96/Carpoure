using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class BotCarController : MonoBehaviour
    {
        private enum State
        {
            None = 0,
            Moving
        }

        [SerializeField, AssetsOnly] private CarStatesArray _statesArray;

        [SerializeField] private Transform _carTransform;
        [SerializeField] private Transform[] _wheels;

        private State _state = State.None;
        private DateTime _startTime;
        private int _lastStateNumber;

        private void Awake()
        {
            LevelStateMachine.Instance.LevelStarted += StartMove;
            LevelStateMachine.Instance.LevelFinished += StopMoving;
            LevelStateMachine.Instance.LevelFailed += StopMoving;
        }

        private void Update()
        {
            if (_state == State.Moving)
                ApplyNextState();
        }

        private void OnDestroy()
        {
            if (LevelStateMachine.IsInstanceExist)
            {
                LevelStateMachine.Instance.LevelStarted -= StartMove;
                LevelStateMachine.Instance.LevelFinished -= StopMoving;
                LevelStateMachine.Instance.LevelStarted -= StopMoving;
            }
        }

        [Button]
        private void MoveToStartPosition() => ApplyState(_statesArray.GetByIndex(0));

        private void StartMove()
        {
            _state = State.Moving;
            _startTime = DateTime.Now;
        }

        private void StopMoving() => _state = State.None;

        private void ApplyNextState()
        {
            if (_lastStateNumber < _statesArray.StatesCount)
            {
                double time = DateTime.Now.Subtract(_startTime).TotalMilliseconds;
                ApplyState(_statesArray.GetByTimeAndIndex(time, _lastStateNumber, out int newIndex));
                _lastStateNumber = newIndex;
            }
        }

        private void ApplyState(CarState carState)
        {
            if (carState.WheelsRotation == null)
                return;

            _carTransform.SetPositionAndRotation(carState.Position, carState.Rotation);

            for (int i = 0; i < _wheels.Length; i++)
                _wheels[i].rotation = carState.WheelsRotation[i];
        }
    }
}