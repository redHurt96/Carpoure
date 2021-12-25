using RH.Utilities.SingletonAccess;
using System;

public class CollectablesMaganer : MonoBehaviourSingleton<CollectablesMaganer>
{
    public event Action CountChanged;

    public int Count 
    { 
        get => _count;
        private set
        {
            var previousCount = _count;
            _count = value;

            if (_count != previousCount)
                CountChanged?.Invoke();
        }
    }

    private int _count;

    private void Start() => 
        LevelStateMachine.Instance.LevelRestarted += ResetCount;

    private void ResetCount() => 
        Count = 0;

    internal void AddItem(CollectableObject collectable) => 
        Count += collectable.Value;
}