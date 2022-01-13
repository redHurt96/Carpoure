using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.Car.WithLocalGravity
{
    public class GroundNormalCalculator : MonoBehaviour
    {
        public Vector3 Value { get; private set; }

        [SerializeField] private WheelCollider[] _wheelColliders;

        private void Update() => CalculateGravity();

        private void CalculateGravity()
        {
            List<Vector3> normals = new List<Vector3>();
            Vector3 sum = Vector3.zero;

            foreach (WheelCollider wheel in _wheelColliders)
            {
                if (wheel.GetGroundHit(out WheelHit hit))
                {
                    normals.Add(hit.normal);
                    sum += hit.normal;
                }
            }

            if (normals.Count > 0)
                Value = sum / normals.Count;
            else
                Value = Vector3.zero;
        }
    }
}