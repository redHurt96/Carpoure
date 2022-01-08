using UnityEngine;

namespace RoofRace.CarV2
{
    [RequireComponent(typeof(GroundDetector))]
    public class LocalGravityApplier : MonoBehaviour
    {
        [SerializeField] private float _force;

        private Rigidbody _rigidbody;
        private GroundDetector _groundDetector;

        private Vector3 _normal => _groundDetector.Normal;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        private void Update()
        {
            transform.up = -_normal.normalized;

            if (!_groundDetector.IsGrounded)
                _rigidbody.velocity -= _normal.normalized * _force;
        }
    }
}