using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class FailLevelZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider) && other.CompareTag(Tags.PLAYER))
                LevelStateMachine.Instance.FailLevel();
        }
    }
}