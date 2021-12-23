using UnityEngine;

public class GravityChangerToValue : MonoBehaviour
{
    [SerializeField] private Vector3 _nextDirecton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Physics.gravity = _nextDirecton;
    }
}