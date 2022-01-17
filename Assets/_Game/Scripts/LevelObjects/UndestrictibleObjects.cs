using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.LevelObjects
{
    public class UndestrictibleObjects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosion;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.PLAYER))
            {
                LevelStateMachine.Instance.FailLevel();
                _explosion.Play();
            }
        }

        #region EDITOR TOOLS
#if UNITY_EDITOR

        [Button]
        private void Prepare()
        {
            PrepareCollider();
            PrepareFx();
        }

        [Button]
        private void PrepareFx()
        {
            _explosion = Instantiate(Resources.Load("BigExplosion") as GameObject, transform)
                            .GetComponent<ParticleSystem>();
        }

        private void PrepareCollider()
        {
            if (GetComponent<Collider>() == null)
                gameObject.AddComponent<MeshCollider>();
        }

#endif
        #endregion
    }
}