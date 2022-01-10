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
    }
}