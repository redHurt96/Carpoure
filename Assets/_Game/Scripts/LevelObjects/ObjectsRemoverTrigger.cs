using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class ObjectsRemoverTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject[] _removable;

        private void OnTriggerEnter(Collider other)
        {
            foreach (GameObject item in _removable)
                item.SetActive(false);
        }
    }
}