using RoofRace.Physics;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class GravityChangingZone : MonoBehaviour
    {
        [SerializeField] private GravityDirection _insideDirecton;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Gravity.Change(_insideDirecton);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                Gravity.Change(GravityDirection.Default);
        }
    }
}