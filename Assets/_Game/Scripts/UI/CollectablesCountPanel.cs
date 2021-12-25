using UnityEngine;
using UnityEngine.UI;

public class CollectablesCountPanel : MonoBehaviour
{
    [SerializeField] private Text _value;

    private void Start()
    {
        CollectablesMaganer.Instance.CountChanged += UpdateText;
    }

    private void UpdateText()
    {
        _value.text = CollectablesMaganer.Instance.Count.ToString();
    }
}