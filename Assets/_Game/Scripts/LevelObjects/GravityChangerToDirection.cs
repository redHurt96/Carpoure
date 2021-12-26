using RoofRace.Physics;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class GravityChangerToDirection : MonoBehaviour
    {
        [SerializeField] private GravityDirection _nextDirecton;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                GravityChanger.Change(_nextDirecton);
        }
    }
}