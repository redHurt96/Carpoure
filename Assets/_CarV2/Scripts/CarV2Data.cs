using UnityEngine;

namespace RoofRace.CarV2
{
    [CreateAssetMenu(fileName = "CarV2Data", menuName = "Game/Create carV2 data", order = 0)]
    public class CarV2Data : ScriptableObject
    {
        public float GravityForce;
        public float MaxGravitySpeed;

        [Space]
        public float MaxForwardSpeed;
        public float ForwardAcceleration;

        [Space(5)]
        public float MaxSideSpeed;
        public float SideAcceleration;

        public float MaxTotalSpeed => new Vector2(MaxForwardSpeed, MaxSideSpeed).magnitude;

        #region SINGLETON

        public static CarV2Data Instance { get; private set; }

        public void CreateInstance()
        {
            Instance = this;
        }

        #endregion
    }
}