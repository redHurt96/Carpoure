using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class FinishLevelZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CarCollider>(out var carCollider))
                LevelStateMachine.Instance.FinishLevel();
        }
    }
}