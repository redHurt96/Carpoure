using RoofRace.Car.WithLocalGravity;
using UnityEngine;

namespace RoofRace.Car
{
    [RequireComponent(typeof(InAirTimer))]
    public class InAirAligner : MonoBehaviour
    {
        [SerializeField] private LocalGravityApplier _localGravityApplier;

        [SerializeField] private float _timeBeforeAlign = .2f;
        [SerializeField] private float _smoothValue = .75f;

        private InAirTimer _timer;
        private bool _isTrasking = false;

        private void Awake()
        {
            _timer = GetComponent<InAirTimer>();
            LevelStateMachine.Instance.LevelStarted += StartTracking;
        }

        private void StartTracking()
        {
            LevelStateMachine.Instance.LevelStarted -= StartTracking;
            _isTrasking = true;
        }

        private void FixedUpdate()
        {
            if (_timer.Value > _timeBeforeAlign && _isTrasking)
                transform.up = Vector3.LerpUnclamped(transform.up, -_localGravityApplier.Value.normalized, _smoothValue);
        }
    }
}