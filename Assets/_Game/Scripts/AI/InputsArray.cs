using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;

namespace RoofRace.AI
{
    [CreateAssetMenu(fileName = "New AiInputArray", menuName = "Ai/CarInputArray", order = 0)]
    public class InputsArray : ScriptableObject
    {
        [SerializeField] private AiInputData[] Data;

        public AiInputData GetByTime(TimeSpan timeSpan) => 
            Data.Last(x => x.Time >= timeSpan.TotalMilliseconds);

        //[Button]
        //private void CheckInputs()
        //{

        //}
    }
}