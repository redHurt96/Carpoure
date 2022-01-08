using UnityEngine;

namespace RoofRace.CarV2
{
    [RequireComponent(typeof(Rigidbody))]
    public class Accelerator : MonoBehaviour
    {
        private CarV2Data _carV2Data => CarV2Data.Instance;

        private Rigidbody _rigidbody;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody>();

        private void Update()
        {
            if (_rigidbody.velocity.z < _carV2Data.MaxForwardSpeed)
                _rigidbody.AddForce(Vector3.forward * _carV2Data.ForwardAcceleration);
        }
    }
}