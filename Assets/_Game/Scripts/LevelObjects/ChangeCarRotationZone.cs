using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class ChangeCarRotationZone : MonoBehaviour
    {
        [SerializeField] private float _value = .02f;
        private float _originValue;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var collider))
            {
                _originValue = collider.Input.RotationTreshhold; 
                collider.Input.ChangeRotationTreshhold(_value);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var collider))
                collider.Input.ChangeRotationTreshhold(_originValue);
        }
    }
}