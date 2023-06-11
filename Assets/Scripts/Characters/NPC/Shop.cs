using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshPro moneyAmountMesh;
    [SerializeField] private int moneyAmount;
    [SerializeField] private GameObject player;
    [SerializeField] private MoneyScriptable playerMoney;
    [SerializeField] private GameObject itemPrefab;

    private void Awake()
    {
        player.GetComponent<PlayerBuy>().BuyItemEvent += Buyitem;
    }

    private void Update()
    {
        moneyAmountMesh.text = moneyAmount.ToString();
    }

    private void OnDisable()
    {
        if (player != null)
            player.GetComponent<PlayerBuy>().BuyItemEvent -= Buyitem;
    }

    private void Buyitem()
    {
        if(playerMoney.Money >= moneyAmount)
        {
            playerMoney.Money -= moneyAmount;
            moneyAmount++;
            Instantiate(itemPrefab, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), Quaternion.identity);
        }
    }
}
