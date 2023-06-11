using UnityEngine;
using DialogueEditor;

public class BuyingDoll : MonoBehaviour
{
    [SerializeField] private MoneyScriptable playerMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (playerMoney.Money >= 150)
            {
                ConversationManager.Instance.SetBool("enoughMoney", true);
                playerMoney.Money -= 150;
            }  
            else
                ConversationManager.Instance.SetBool("enoughMoney", false);
        }
    }
}
