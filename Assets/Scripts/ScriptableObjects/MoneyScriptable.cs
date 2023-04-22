using UnityEngine;

[CreateAssetMenu(fileName = "New MoneyAmount", menuName = "Pickups/MoneyAmount", order = 1)]
public class MoneyScriptable : ScriptableObject
{
    [SerializeField] private int money;

    public int Money
    {
        get { return money; }
        set { money = value; }
    }
}