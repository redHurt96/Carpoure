using UnityEngine;

[RequireComponent(typeof(InAirTimer))]
public class InAirAligner : MonoBehaviour
{
    [SerializeField] private float _timeBeforeAlign = .2f;

    private InAirTimer _timer;
    private bool _hasAligned;

    private void Awake() => 
        _timer = GetComponent<InAirTimer>();

    private void Update()
    {
        if (_timer.Value > _timeBeforeAlign && !_hasAligned)
        {
            transform.up = -Physics.gravity.normalized;
            _hasAligned = true;
        }
        else if (_timer.Value < _timeBeforeAlign)
        {
            _hasAligned = false;
        }
    }
}