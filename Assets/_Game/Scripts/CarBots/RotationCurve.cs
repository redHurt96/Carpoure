using System;
using UnityEngine;

namespace RoofRace.Bots
{
    [Serializable]
    public class RotationCurve
    {
        [SerializeField] private AnimationCurve X = new AnimationCurve();
        [SerializeField] private AnimationCurve Y = new AnimationCurve();
        [SerializeField] private AnimationCurve Z = new AnimationCurve();
        [SerializeField] private AnimationCurve W = new AnimationCurve();

        public void AddKey(Quaternion value, float atTime)
        {
            X.AddKey(atTime, value.x);
            Y.AddKey(atTime, value.y);
            Z.AddKey(atTime, value.z);
            W.AddKey(atTime, value.w);
        }

        public Quaternion Evaluate(float time) =>
            new Quaternion(X.Evaluate(time), Y.Evaluate(time), Z.Evaluate(time), W.Evaluate(time));
    }
}