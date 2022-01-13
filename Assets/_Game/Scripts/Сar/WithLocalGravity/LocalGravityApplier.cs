using KartGame.KartSystems;
using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.Car.WithLocalGravity
{
    public class LocalGravityApplier : MonoBehaviour
    {
        public Vector3 Value { get; private set; }

        [SerializeField] private ArcadeKart _kart;
        [SerializeField] private WheelCollider[] _wheelColliders;

        [Space]
        [SerializeField] private float _gravityForce;

        private void FixedUpdate()
        {
            CalculateGravity();
            ApplyGravity();
            //DrawDebugLine();
        }

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
                Value = sum;
        }

        private void ApplyGravity()
        {
            if (Value != Vector3.zero)
                _kart.baseStats.AddedGravity = -Value.normalized * _gravityForce;
        }

        private void DrawDebugLine()
        {
            Debug.DrawLine(transform.position, transform.position + Value * 3f, Color.red, 10f);
        }
    }
}