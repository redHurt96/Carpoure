using System;
using UnityEngine;

namespace RoofRace.Bots
{
    [Serializable]
    public class PositionCurve
    {
        [SerializeField] private AnimationCurve X = new AnimationCurve();
        [SerializeField] private AnimationCurve Y = new AnimationCurve();
        [SerializeField] private AnimationCurve Z = new AnimationCurve();

        public void AddKey(Vector3 value, float atTime)
        {
            X.AddKey(atTime, value.x);
            Y.AddKey(atTime, value.y);
            Z.AddKey(atTime, value.z);
        }

        public Vector3 Evaluate(float time) => 
            new Vector3(X.Evaluate(time), Y.Evaluate(time), Z.Evaluate(time));
    }
}