using System;

namespace RoofRace.CarBots
{
    [Serializable]
    public class UserInput
    {
        public float HorizontalInput;

        public double StartTime;
        public double FinishTime;

        public UserInput(float input, double startTime)
        {
            StartTime = startTime;
            HorizontalInput = input;
            FinishTime = -1;
        }
    }
}