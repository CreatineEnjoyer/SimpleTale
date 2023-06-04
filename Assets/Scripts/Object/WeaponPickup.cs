using System;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public static event Action<WeaponPickup> WeaponPickupEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            WeaponPickupEvent?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
