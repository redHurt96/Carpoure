using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class FailLevelZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                LevelStateMachine.Instance.FailLevel();
        }
    }
}