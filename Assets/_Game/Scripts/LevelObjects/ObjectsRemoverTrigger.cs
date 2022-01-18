using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class ObjectsRemoverTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject[] _removable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
                SetActiveObjects(false);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
                SetActiveObjects(true);
        }

        private void SetActiveObjects(bool value)
        {
            foreach (GameObject item in _removable)
                item.SetActive(value);
        }
    }
}