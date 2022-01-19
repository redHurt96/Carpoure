using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.Bots
{
    public class CarPath : ScriptableObject
    {
        public Vector3 StartPosition => _startPosition;

        [SerializeField] private Vector3 _startPosition;

        [SerializeField] private PositionCurve _position = new PositionCurve();
        [SerializeField] private RotationCurve _rotation = new RotationCurve();

        [SerializeField] private RotationCurve[] _wheelsRotations = new RotationCurve[4]
        {
            new RotationCurve(),
            new RotationCurve(),
            new RotationCurve(),
            new RotationCurve()
        };

        public void Add(Vector3 startPosition) => _startPosition = startPosition;

        public void Add(CarState state, float atTime)
        {
            _position.AddKey(state.Position, atTime);
            _rotation.AddKey(state.Rotation, atTime);

            for (int i = 0; i < state.WheelsRotations.Length; i++)
                _wheelsRotations[i].AddKey(state.WheelsRotations[i], atTime);
        }

        public CarState GetByTime(float time)
        {
            var state = new CarState
            {
                Position = _position.Evaluate(time),
                Rotation = _rotation.Evaluate(time),
            };

            state.WheelsRotations = new Quaternion[4];

            for (int i = 0; i < state.WheelsRotations.Length; i++)
                state.WheelsRotations[i] = _wheelsRotations[i].Evaluate(time);

            return state;
        }

        [Button]
        private void PrintLogs()
        {
            Debug.Log($"Position curve lenght = {_position.GetLenght()}");
            Debug.Log($"Rotation curve lenght = {_position.GetLenght()}");

            for (int i = 0; i < _wheelsRotations.Length; i++)
                Debug.Log($"Wheel {i} curve lenght = {_wheelsRotations[i].GetLenght()}");
        }
    }
}