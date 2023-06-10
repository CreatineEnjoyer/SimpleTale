using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private MoneyScriptable playerMoney;
    [SerializeField] private TextMeshProUGUI playerMoneyUI;

    void Update()
    {
        playerMoneyUI.text = playerMoney.Money.ToString();
    }
}
