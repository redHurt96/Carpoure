using RoofRace.Logic;
using UnityEngine;

namespace RoofRace.UI
{
    public class NitroButtonVisibilityChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _button;

        private void Start()
        {
            NitroManager.Instance.CountChanged += UpdateButtonVisibility;
            _button.SetActive(false);
        }

        private void OnDestroy()
        {
            if (NitroManager.IsInstanceExist)
                NitroManager.Instance.CountChanged -= UpdateButtonVisibility;
        }

        private void UpdateButtonVisibility() => _button.SetActive(NitroManager.Instance.Count >= NitroManager.Instance.MaxCount);
    }
}