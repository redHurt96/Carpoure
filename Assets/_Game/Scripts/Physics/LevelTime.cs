using UnityEngine;

namespace RoofRace.Physics
{
    public static class LevelTime
    {
        private const float SLOW_MOTION_SCALE = .1f;

        public static void ResetToDefault() => Change(1f);
        public static void EnableSlowMotion() => Change(SLOW_MOTION_SCALE);

        private static void Change(float to) => Time.timeScale = to;
    }
}