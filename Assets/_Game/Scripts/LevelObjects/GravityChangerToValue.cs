using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class GravityChangerToValue : MonoBehaviour
    {
        [SerializeField] private Vector3 _nextDirecton;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                UnityEngine.Physics.gravity = _nextDirecton;
        }
    }
}