using UnityEngine;

internal class CollectableObject : MonoBehaviour
{
    public int Value => _value;

    [SerializeField] private int _value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            CollectablesMaganer.Instance.AddItem(this);
            Destroy(gameObject);
        }
    }
}
