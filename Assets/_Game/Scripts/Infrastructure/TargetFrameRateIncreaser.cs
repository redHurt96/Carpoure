using UnityEngine;

public class TargetFrameRateIncreaser : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}