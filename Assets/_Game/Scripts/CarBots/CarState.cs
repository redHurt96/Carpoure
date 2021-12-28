using System;
using UnityEngine;

namespace RoofRace.CarBots
{
    [Serializable]
    public struct CarState
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Quaternion[] WheelsRotation;
        public double TimeSinceStart;
    }
}