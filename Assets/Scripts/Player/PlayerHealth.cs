using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour, ITakingDamage
{
    [SerializeField] private HealthScriptable playerHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient healthColor;
    [SerializeField] private Image contaminationProcess;

    private int health;
    public event Action DeathEvent;
    private float temp = 0f;

    private void Start()
    {
        health = playerHealth.Health;
        slider.value = health;
        contaminationProcess.color = healthColor.Evaluate(1f);
    }

    private void Update()
    {
        ContaminationInProcess();
    }

    private void ContaminationInProcess()
    {
        if (health <= 0) DeathEvent?.Invoke();

        if (health <= 20)
        {
            temp += Time.deltaTime;
            if(temp > 10f)
            {
                health -= 1;
                UpdateHealth();
                temp = 0f;
            }
        }
    }

    private void UpdateHealth()
    {
        slider.value = health;
        contaminationProcess.color = healthColor.Evaluate(slider.normalizedValue);
    }

    public void TakeDamage(int strength)
    {
        health -= strength;
        UpdateHealth();
        if (health <= 0) DeathEvent?.Invoke();
    }
}
