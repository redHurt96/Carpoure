using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    [RequireComponent(typeof(Collider))]
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 50f;
        [SerializeField] private float _radius = 5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
            {
                //Vector3 point = other.ClosestPoint(transform.position);
                MoveChildObjects(other.transform.position);
            }
        }

        private void MoveChildObjects(Vector3 from)
        {
            foreach (Transform child in transform)
            {
                Rigidbody rigidbody = child.GetComponent<Rigidbody>();

                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(_explosionForce, from, _radius);
            }
        }

        [Button]
        private void PrepareChildObjects()
        {
            foreach (Transform child in transform)
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