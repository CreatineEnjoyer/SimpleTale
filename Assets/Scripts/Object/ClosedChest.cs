using System;
using UnityEngine;

public class ClosedChest : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health;

    public event Action DeathEvent;

    void ITakeDamage.TakeDamage(int strength)
    {
        health -= strength;
        if (health <= 0) DeathEvent?.Invoke();
    }
}
