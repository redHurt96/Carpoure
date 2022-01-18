using System;
using UnityEngine;

namespace RoofRace.Collectables
{
    [RequireComponent(typeof(Collider))]
    internal class CollectableObject : MonoBehaviour
    {
        public event Action Collected;

        public int Value => _value;

        [SerializeField] private int _value = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER))
            {
                CollectablesMaganer.Instance.AddItem(this);

                Collected?.Invoke();

                Destroy(gameObject, .1f);
            }
        }
    }
}