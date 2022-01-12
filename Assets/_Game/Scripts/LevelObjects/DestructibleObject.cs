using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    [RequireComponent(typeof(Collider))]
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private GameObject _origin;
        [SerializeField] private Transform _broken;

        [SerializeField] private float _explosionForce = 50f;
        [SerializeField] private float _radius = 5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
                Blast(other.transform.position);
        }

        private void Blast(Vector3 from)
        {
            Destroy(_origin);

            _broken.gameObject.SetActive(true);

            foreach (Transform child in _broken)
                PushChild(from, child);
        }

        private void PushChild(Vector3 from, Transform child)
        {
            Rigidbody rigidbody = child.GetComponent<Rigidbody>();

            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(_explosionForce, from, _radius);
        }

        [Button]
        private void Prepare()
        {
            _broken.gameObject.SetActive(false);

            GetComponent<Collider>().isTrigger = true;

            foreach (Transform child in _broken)
            {
                if (child.GetComponent<MeshCollider>() == null)
                    child.gameObject.AddComponent<MeshCollider>();

                if (child.GetComponent<Rigidbody>() == null)
                    child.gameObject.AddComponent<Rigidbody>();

                child.GetComponent<MeshCollider>().convex = true;
                child.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}