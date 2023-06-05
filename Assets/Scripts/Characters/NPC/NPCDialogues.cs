using DialogueEditor;
using UnityEngine;

public class NPCDialogues: MonoBehaviour
{
    [SerializeField] private NPCConversation npcConversation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            ConversationManager.Instance.StartConversation(npcConversation);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            ConversationManager.Instance.EndConversation();
        }
    }
}
