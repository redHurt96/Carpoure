using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.CarV2
{
    public class GroundDetector : MonoBehaviour
    {
        public bool IsGrounded => _colliders.Count > 0;
        public Vector3 Normal { get; private set; }

        private List<Collider> _colliders = new List<Collider>();

        private void OnCollisionEnter(Collision collision)
        {
            AddCollider(collision);
            Normal = collision.contacts[0].normal;
        }

        private void OnCollisionExit(Collision collision)
        {
            RemoveCollider(collision);
            Normal = Vector3.up;
        }

        private void AddCollider(Collision collision)
        {
            if (!_colliders.Contains(collision.collider))
                _colliders.Add(collision.collider);
        }

        private void RemoveCollider(Collision collision)
        {
            if (_colliders.Contains(collision.collider))
                _colliders.Remove(collision.collider);
        }
    }
}