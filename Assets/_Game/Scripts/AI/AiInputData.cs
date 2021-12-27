using System;

namespace RoofRace.AI
{
    [Serializable]
    public struct AiInputData
    {
        public bool Acceleration;
        public float TurnInput;
        public float Time;
    }
}