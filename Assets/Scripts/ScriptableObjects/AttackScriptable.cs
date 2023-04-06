using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackStats", menuName ="Stats/Attack")]
public class AttackScriptable : ScriptableObject
{
    [SerializeField] private int strength;
    [SerializeField] private float range;

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public float Range
    {
        get { return range; }
        set { range = value; }
    }
}
