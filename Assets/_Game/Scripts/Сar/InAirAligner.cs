using RoofRace.Physics;
using UnityEngine;

namespace RoofRace.Car
{
    [RequireComponent(typeof(InAirTimer))]
    public class InAirAligner : MonoBehaviour
    {
        [SerializeField] private float _timeBeforeAlign = .2f;

        private InAirTimer _timer;
        private bool _isAlligned = false;

        private void Awake() => _timer = GetComponent<InAirTimer>();

        private void FixedUpdate()
        {
            if (_timer.Value > _timeBeforeAlign && !_isAlligned)
            {
                transform.up = -Gravity.Value.normalized;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                _isAlligned = true;
            }
            else if (_timer.Value < _timeBeforeAlign)
            {
                _isAlligned = false;
            }
        }
    }
}