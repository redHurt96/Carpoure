using KartGame.KartSystems;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class BotCarController : BaseInput
    {
        [SerializeField, AssetsOnly] private CarStatesArray _statesArray;

        [SerializeField] private ArcadeKart _kart;

        private DateTime _startTime;
        private int _lastStateNumber;

        private void Awake()
        {
            LevelStateMachine.Instance.LevelStarted += StartMove;
        }

        private void OnDestroy()
        {
            if (LevelStateMachine.IsInstanceExist)
                LevelStateMachine.Instance.LevelStarted -= StartMove;
        }

        [Button]
        private void MoveToStartPosition() =>
            transform.position = _statesArray.StartPosition;

        private void StartMove()
        {
            _startTime = DateTime.Now;
            _kart.enabled = true;
        }

        public override InputData GenerateInput()
        {
            return new InputData
            {
                Accelerate = true,
                Brake = false,
                TurnInput = GetInput()
            };
        }

        private float GetInput() => 
            _statesArray.GetState(DateTime.Now.Subtract(_startTime).TotalMilliseconds);
    }
}