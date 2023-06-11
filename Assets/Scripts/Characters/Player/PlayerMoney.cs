using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private MoneyScriptable playerMoney;
    [SerializeField] private TextMeshProUGUI playerMoneyUI;

    private void Start()
    {
        playerMoney.Money = 0;
    }

    void Update()
    {
        playerMoneyUI.text = playerMoney.Money.ToString();
    }
}
