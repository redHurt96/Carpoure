#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoofRace.CarBots
{
    public class CarPath : ScriptableObject
    {
        public Vector3 StartPosition => _startPosition;

        [SerializeField] private Vector3 _startPosition;

        [SerializeField] private List<CarState> _carStates = new List<CarState>();

        public void Add(Vector3 startPosition) => _startPosition = startPosition;
        public void Add(CarState state)
        {
            if (_carStates.Count > 0)
                state.StartTime = _carStates.Last().FinishTime;

            _carStates.Add(state);
        }

        public CarState GetByTime(double time) => 
            _carStates.First(x => x.StartTime <= time && x.FinishTime >= time);
    }
}

#endif