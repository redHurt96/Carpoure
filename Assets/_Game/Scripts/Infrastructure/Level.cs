using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoofRace
{
    public class Level : MonoBehaviour
    {
        public Transform StartPoint;

        [SerializeField] private Transform EndPoint;

        public float CalculateProgress(Transform forObject) => 
            Mathf.InverseLerp(StartPoint.position.z, EndPoint.position.z, forObject.position.z);
    }
}