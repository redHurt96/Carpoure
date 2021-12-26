using System.Collections.Generic;
using UnityEngine;

namespace RoofRace.Physics
{
    public static class GravityChanger
    {
        private const float GRAVITY_FORCE = 10;

        public static readonly Dictionary<GravityDirection, Vector3> DIRECTIONS = new Dictionary<GravityDirection, Vector3>
        {
            { GravityDirection.Left, Vector3.left * GRAVITY_FORCE },
            { GravityDirection.Right, Vector3.right * GRAVITY_FORCE },
            { GravityDirection.Default, Vector3.down * GRAVITY_FORCE }
        };

        public static void Change(GravityDirection to) =>
            UnityEngine.Physics.gravity = DIRECTIONS[to];
    }

    public enum GravityDirection
    {
        Default = 0,
        Left,
        Right,
    }
}