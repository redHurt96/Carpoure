#if UNITY_EDITOR

using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    [Serializable]
    public class CarState
    {
        public double StartTime;
        public double FinishTime;

        public Vector3 Position;
        public Quaternion Rotation;

        public Quaternion[] WheelsRotations;
    }
}

#endif