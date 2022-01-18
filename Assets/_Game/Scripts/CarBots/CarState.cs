#if UNITY_EDITOR

using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    [Serializable]
    public class CarState
    {
        public double Time;

        public Vector3 Position;
        public Quaternion Rotation;

        public Quaternion[] WheelsRotations;
    }
}

#endif