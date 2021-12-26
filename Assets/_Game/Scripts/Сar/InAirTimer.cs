using UnityEngine;

namespace RoofRace.Car
{
    [RequireComponent(typeof(GroundedStateIndicator))]
    public class InAirTimer : MonoBehaviour
    {
        public float Value { get; private set; }

        private GroundedStateIndicator _indicator;

        private void Awake()
        {
            _indicator = GetComponent<GroundedStateIndicator>();
        }

        private void Update()
        {
            if (_indicator.IsGrounded)
                Value = 0f;
            else
                Value += Time.deltaTime;
        }
    }
}