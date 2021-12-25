using RH.Utilities.SingletonAccess;
using UnityEngine;

public class LevelStateMachine : MonoBehaviourSingleton<LevelStateMachine>
{
    [SerializeField] private PlayerCar _carPrefab;
    [SerializeField] private CameraLookPoint _cameraLookPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private LevelCamera _levelCamera;

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
        _levelCamera.RotateAround(_car.transform);
        _finishUi.SetActive(true);
    }

    internal void FailLevel()
    {
        _failUi.SetActive(true);
    }

    internal void GoToNextLevel()
    {
        SwitchToStartState();
    }

    internal void RestartLevel()
    {
        SwitchToStartState();
    }

    private void SwitchToStartState()
    {
        if (_car != null)
            Destroy(_car.gameObject);

        _car = Instantiate(_carPrefab, _startPoint.position, Quaternion.identity);
        _cameraLookPoint.AttachTarget(_car.transform);
        _levelCamera.ResetToDefaultState();

        _startUi.SetActive(true);
        _finishUi.SetActive(false);
        _failUi.SetActive(false);
    }
}
