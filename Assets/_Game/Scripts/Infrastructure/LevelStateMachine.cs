using RH.Utilities.SingletonAccess;
using UnityEngine;

public class LevelStateMachine : MonoBehaviourSingleton<LevelStateMachine>
{
    [SerializeField] private PlayerCar _carPrefab;
    [SerializeField] private CameraLookPoint _cameraLookPoint;
    [SerializeField] private Transform _startPoint;


    [Header("UI")]
    [SerializeField] private GameObject _startUi;
    [SerializeField] private GameObject _finishUi;
    [SerializeField] private GameObject _failUi;

    private PlayerCar _car;


    private void Start()
    {
        SwitchToStartState();
    }

    internal void StartLevel()
    {
        _startUi.SetActive(false);
        _car.Enable();
    }

    internal void FinishLevel()
    {
        _finishUi.SetActive(true);
    }

    internal void FailLevel()
    {
        _failUi.SetActive(true);
    }

    internal void GoToNextLevel()
    {
        Destroy(_car.gameObject);
        SwitchToStartState();
    }

    internal void RestartLevel()
    {
        Destroy(_car.gameObject);
        SwitchToStartState();
    }

    private void SwitchToStartState()
    {
        _car = Instantiate(_carPrefab, _startPoint.position, Quaternion.identity);
        _cameraLookPoint.AttachTarget(_car.transform);

        _startUi.SetActive(true);
        _finishUi.SetActive(false);
        _failUi.SetActive(false);
    }
}
