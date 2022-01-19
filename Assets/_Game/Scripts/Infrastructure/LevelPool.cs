using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.Infrastructure
{
    public class LevelPool : MonoBehaviour
    {
        [SerializeField, AssetsOnly] private Level[] _levelsPrefabs;

        public int Current { get; private set; }

        public Level GetCurrent() => _levelsPrefabs[Current];

        public Level GetNext()
        {
            IncreaseIndex();
            return _levelsPrefabs[Current];
        }

        private void IncreaseIndex()
        {
            Current++;
            Current %= _levelsPrefabs.Length;
        }
    }
}