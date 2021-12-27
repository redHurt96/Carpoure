using KartGame.KartSystems;
using System;
using UnityEngine;

namespace RoofRace.AI
{
    public class AiInput : BaseInput
    {
        [SerializeField] private InputsArray _inputsArray;

        private DateTime _startTime;

        public void Enable()
        {
            _startTime = DateTime.Now;
        }

        public override InputData GenerateInput()
        {
            var aiInput = GetInput();

            return new InputData
            {
                Accelerate = aiInput.Acceleration,
                Brake = false,
                TurnInput = aiInput.TurnInput
            };
        }

        private AiInputData GetInput() => 
            _inputsArray.GetByTime(DateTime.Now.Subtract(_startTime));
    }
}