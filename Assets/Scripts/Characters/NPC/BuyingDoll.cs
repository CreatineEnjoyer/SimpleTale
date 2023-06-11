using UnityEngine;
using DialogueEditor;

public class BuyingDoll : MonoBehaviour
{
    [SerializeField] private MoneyScriptable playerMoney;
    [SerializeField] private GameObject dollPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (playerMoney.Money >= 150)
            {
                ConversationManager.Instance.SetBool("enoughMoney", true);
                playerMoney.Money -= 150;
                Instantiate(dollPrefab, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), Quaternion.identity);
            }  
            else
                ConversationManager.Instance.SetBool("enoughMoney", false);
        }
    }
}
