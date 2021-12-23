using UnityEngine;

public class CameraLookPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _offset;

    private void Awake()
    {
        _offset = transform.position.z - _target.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, _target.position.z + _offset);
    }
}
