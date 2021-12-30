using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class ChangeCarGravityZone : MonoBehaviour
    {
        private static readonly Vector3 DEFAULT = Vector3.zero;

        [SerializeField] private Vector3 _insideDirection;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                carCollider.Kart.baseStats.AddedGravity = _insideDirection;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                carCollider.Kart.baseStats.AddedGravity = DEFAULT;
        }
    }
}