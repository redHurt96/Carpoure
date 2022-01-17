using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    [RequireComponent(typeof(Collider))]
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private GameObject _origin;
        [SerializeField] private Transform _broken;

        [SerializeField] private float _explosionForce = 5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
                Blast(other.transform.position);
        }

        private void Blast(Vector3 from)
        {
            DestroyOrigin();
            ActivateBrokenObjects();
            PushChildren(from);
        }

        private void DestroyOrigin()
        {
            if (_origin != null)
                Destroy(_origin);
        }

        private void ActivateBrokenObjects() => _broken.gameObject.SetActive(true);

        private void PushChildren(Vector3 @from)
        {
            foreach (Transform child in _broken)
                PushChild(@from, child);
        }

        private void PushChild(Vector3 from, Transform child)
        {
            Rigidbody rigidbody = child.GetComponent<Rigidbody>();

            rigidbody.isKinematic = false;
            rigidbody.AddForce(((child.position - from).normalized + Random.insideUnitSphere) * _explosionForce, ForceMode.Impulse);
        }

        #region EDITOR TOOLS
#if UNITY_EDITOR
        [Button]
        private void Prepare()
        {
            PrepareMainObjects();

            foreach (Transform child in _broken)
                PrepareChild(child);
        }

        [Button]
        private void PrepareFromEmptyFields()
        {
            _origin = new GameObject("Origin");
            _origin.transform.SetParent(transform);

            _broken = new GameObject("Broken").transform;
            _broken.transform.SetParent(transform);

            PrepareMainObjects();

            while (transform.childCount > 2)
            {
                var child = transform.GetChild(0);

                child.SetParent(_broken);
                PrepareChild(child);
            }
        }

        private void PrepareMainObjects()
        {
            _broken.gameObject.SetActive(false);

            GetComponent<Collider>().isTrigger = true;
        }

        private static void PrepareChild(Transform child)
        {
            if (child.GetComponent<MeshCollider>() == null)
                child.gameObject.AddComponent<MeshCollider>();

            if (child.GetComponent<Rigidbody>() == null)
                child.gameObject.AddComponent<Rigidbody>();

            MeshCollider collider = child.GetComponent<MeshCollider>();
            collider.convex = true;
            collider.isTrigger = true;

            child.GetComponent<Rigidbody>().isKinematic = true;
        }

        [Button]
        private void ShowBroken() => _broken.gameObject.SetActive(true);
#endif
        #endregion
    }
}