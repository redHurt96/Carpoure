using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class CarStatesArray : ScriptableObject
    {
        public Vector3 StartPosition;

        [SerializeField] private List<UserInput> _carStates = new List<UserInput>();

        public void AddState(float inputDirection, double time)
        {
            if (_carStates.Count == 0)
            {
                AddNewState(inputDirection, time);
                return;
            }

            UpdateLastState(inputDirection, time);
        }

        public float GetState(double time)
        {
            for (int i = 0; i < _carStates.Count; i++)
            {
                UserInput state = _carStates[i];

                if (state.StartTime < time && state.FinishTime > time)
                {
                    Debug.Log($"Time = {time}, state {i}, {state.HorizontalInput}");
                    return state.HorizontalInput;
                }
            }

            Debug.Log($"Time = {time}, Return default value");
            return 0;
            //return _carStates.Find(x => x.StartTime < time && x.FinishTime > time).HorizontalInput;
        }

        public float GetState(double time, ref int lastIndex)
        {
            for (; lastIndex < _carStates.Count; lastIndex++)
            {
                var state = _carStates[lastIndex];

                if (state.StartTime < time && time < state.FinishTime)
                    return state.HorizontalInput;
            }

            return 0f;
        }

        private void AddNewState(float inputDirection, double time) =>
            _carStates.Add(new UserInput(inputDirection, time));

        private void UpdateLastState(float inputDirection, double time)
        {
            UserInput lastState = _carStates[_carStates.Count - 1];

            if (lastState.HorizontalInput != inputDirection)
            {
                lastState.FinishTime = time;
                _carStates.Add(new UserInput(inputDirection, time));
            }
        }
    }
}