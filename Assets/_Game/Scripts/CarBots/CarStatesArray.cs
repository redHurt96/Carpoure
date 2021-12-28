using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class CarStatesArray : ScriptableObject
    {
        public int StatesCount => _carStates.Length;

        [SerializeField] private CarState[] _carStates;

        public void SetStates(CarState[] states) => _carStates = states;

        public CarState GetByIndex(int index) => _carStates[index];

        public CarState GetByTimeAndIndex(double timeSinceStart, int lastIndex, out int newIndex)
        {
            if (lastIndex == 0)
            {
                newIndex = 1;
                return _carStates[0];
            }

            for (int i = lastIndex; i < _carStates.Length; i++)
            {
                if (_carStates[i].TimeSinceStart >= timeSinceStart)
                {
                    CarState previousState = _carStates[i - 1];
                    CarState nextState = _carStates[i];

                    double currentSubstactedTime = timeSinceStart - previousState.TimeSinceStart;
                    double nextSubstactedTime = nextState.TimeSinceStart - previousState.TimeSinceStart;

                    float timeLerp = (float)(currentSubstactedTime / nextSubstactedTime);

                    newIndex = i;

                    return new CarState
                    {
                        Position = Vector3.Lerp(previousState.Position, nextState.Position, timeLerp),
                        Rotation = Quaternion.Lerp(previousState.Rotation, nextState.Rotation, timeLerp),
                        WheelsRotation = previousState.WheelsRotation
                    };
                }
            }

            Debug.LogError($"There is no valid car state for time {timeSinceStart} and index {lastIndex}");
            newIndex = 100000000;
            return default;
        }

        [Button]
        private void RemoveAllMiddlePoints()
        {
            var newArray = new CarState[]
            {
                _carStates[0],
                _carStates[_carStates.Length - 1]
            };

            _carStates = newArray;
        }
    }
}