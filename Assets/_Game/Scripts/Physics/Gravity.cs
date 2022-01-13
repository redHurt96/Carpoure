using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.Physics
{
    public static class Gravity
    {
        public static Vector3 Value
        {
            get => UnityEngine.Physics.gravity;
            set => UnityEngine.Physics.gravity = value;
        }

        private const float GRAVITY_FORCE = 10;

        private static readonly Dictionary<GravityDirection, Vector3> DIRECTIONS = new Dictionary<GravityDirection, Vector3>
        {
            { GravityDirection.Left, Vector3.left * GRAVITY_FORCE * 2 },
            { GravityDirection.Right, Vector3.right * GRAVITY_FORCE * 2 },
            { GravityDirection.Default, Vector3.down * GRAVITY_FORCE }
        };

        public static void Change(GravityDirection to) =>
            Value = DIRECTIONS[to];
    }

    public enum GravityDirection
    {
        Default = 0,
        Left,
        Right,
    }
}