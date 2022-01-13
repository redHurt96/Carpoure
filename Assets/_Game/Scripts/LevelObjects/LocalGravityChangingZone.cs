using UnityEngine;

namespace RoofRace.LevelObjects
{

    public class LocalGravityChangingZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction = Vector3.down;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                carCollider.LocalGravityApplier.ApplyDefaultDirection(_direction);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                carCollider.LocalGravityApplier.ApplyDefaultDirection(Vector3.zero);
        }
    }
}