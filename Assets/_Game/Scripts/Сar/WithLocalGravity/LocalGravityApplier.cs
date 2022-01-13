using KartGame.KartSystems;
using RH.Utilities.Attributes;
using UnityEngine;

namespace RoofRace.Car.WithLocalGravity
{
    public class LocalGravityApplier : MonoBehaviour
    {
        public Vector3 Value => _normalCalculator.Value;

        [SerializeField] private GroundNormalCalculator _normalCalculator;
        [SerializeField] private ArcadeKart _kart;

        [Space]
        [SerializeField] private float _gravityForce;

        [Header("Must be readonly")]
        [SerializeField] private Vector3 _defaultGravityDirection = Vector3.zero;
        [SerializeField] private float _angleTreshhold;

        private bool _angleBigEnoughToApplyGravity => Mathf.Abs(Vector3.Angle(Value, Vector3.up)) > _angleTreshhold;

        private void FixedUpdate()
        {
            ApplyGravity();
            DrawDebugLine();
        }

        public void ApplyDefaultDirection(Vector3 value) => _defaultGravityDirection = value;

        private void ApplyGravity()
        {
            if (_angleBigEnoughToApplyGravity)
                ApplyGravity(-Value.normalized);
            else if (_defaultGravityDirection != Vector3.zero)
                ApplyGravity(_defaultGravityDirection);
            else
                ApplyGravity(Vector3.zero);
        }

        private void ApplyGravity(Vector3 direction) => _kart.baseStats.AddedGravity = direction * _gravityForce;

        private void DrawDebugLine() => 
            Debug.DrawLine(transform.position, transform.position + Value * 3f, Color.red, 3f);
    }
}