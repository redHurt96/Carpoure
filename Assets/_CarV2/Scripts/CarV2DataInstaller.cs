using UnityEngine;

namespace RoofRace.CarV2
{
    public class CarV2DataInstaller : MonoBehaviour
    {
        [SerializeField] private CarV2Data _data;

        private void Awake()
        {
            _data.CreateInstance();
        }
    }
}