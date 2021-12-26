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
    }
}