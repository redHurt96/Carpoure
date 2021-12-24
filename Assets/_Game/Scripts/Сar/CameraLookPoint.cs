using UnityEngine;

public class CameraLookPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;

    private void Update()
    {
        if (_target != null)
            transform.position = new Vector3(_target.position.x, _target.position.y, _target.position.z + _offset);
    }

    public void AttachTarget(Transform target)
    {
        _target = target;
    }
}
