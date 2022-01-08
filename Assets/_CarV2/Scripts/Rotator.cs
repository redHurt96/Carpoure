using RH.Utilities.Attributes;
using RH.Utilities.Extensions;
using UnityEngine;

namespace RoofRace.CarV2
{
    [RequireComponent(typeof(Rigidbody), typeof(GroundDetector))]
    public class Rotator : MonoBehaviour
    {
        private CarV2Data _carV2Data => CarV2Data.Instance;

        private Rigidbody _rigidbody;
        private GroundDetector _groundDetector;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        private void Update()
        {
            if (!_groundDetector.IsGrounded)
                return;

            TrySideMove();
        }

        private void TrySideMove()
        {
            float axis = Input.GetAxis("Horizontal");

            if (CanSideMove(axis))
                SideAccelerate(axis);
            else
                _rigidbody.velocity = new Vector3(0f, 0f, _rigidbody.velocity.z);
        }

        private bool CanSideMove(float axis) => 
            _groundDetector.IsGrounded && !axis.Approximately(0f) && !MaxSpeedReachedAtSide(axis);

        private bool MaxSpeedReachedAtSide(float axis) => 
            Vector3.Dot(_rigidbody.velocity, Vector3.right * Mathf.Sign(axis)) > _carV2Data.MaxSideSpeed;

        private void SideAccelerate(float axis) => 
            _rigidbody.velocity += transform.right * axis * _carV2Data.MaxSideSpeed;
    }
}