using RoofRace;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
            Pickup();
    }

    private void Pickup()
    {
        var effect = Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(effect.gameObject, 3f);
    }
}