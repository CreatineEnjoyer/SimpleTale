using System;

public interface ITakeDamage
{
    void TakeDamage(int strength);
    public event Action DeathEvent;
}
