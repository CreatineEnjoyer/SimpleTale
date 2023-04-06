using UnityEngine;

[CreateAssetMenu(fileName = "MeleeHealth", menuName = "Stats/Health")]
public class HealthScriptable : ScriptableObject
{
    [SerializeField] private int health;

    public int Health 
    { 
        get { return health; }
        set { health = value; }
    }
}
