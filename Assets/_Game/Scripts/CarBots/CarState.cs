using System;
using UnityEngine;

namespace RoofRace.Bots
{
    [Serializable]
    public class CarState
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public Quaternion[] WheelsRotations;
    }
}