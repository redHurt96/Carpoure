using RoofRace.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace RoofRace.UI
{
    public class NitroProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;

        private void Start() => NitroManager.Instance.CountChanged += UpdateBar;

        private void OnDestroy()
        {
            if (NitroManager.IsInstanceExist)
                NitroManager.Instance.CountChanged -= UpdateBar;
        }

        private void UpdateBar()
        {
            _fill.fillAmount = NitroManager.Instance.Count / (float)NitroManager.Instance.MaxCount;
            Debug.Log("Fill = " + _fill.fillAmount);
            Debug.Log("Value = " + NitroManager.Instance.Count / (float)NitroManager.Instance.MaxCount);
        }
    }
}