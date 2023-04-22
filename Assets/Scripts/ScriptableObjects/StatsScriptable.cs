using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats/Stats")]
public class StatsScriptable : ScriptableObject
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int strength;
    [SerializeField] private float attackRange;
    [SerializeField] private int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }

    public float DetectionRange
    {
        get { return detectionRange; }
        set { detectionRange = value; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
}
