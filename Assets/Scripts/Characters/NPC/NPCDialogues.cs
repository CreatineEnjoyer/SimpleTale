using DialogueEditor;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Update()
    {
        if (ConversationManager.Instance != null)
        {
             if (ConversationManager.Instance.IsConversationActive)
             {
                 if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                    ConversationManager.Instance.SelectPreviousOption();

                 else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
                    ConversationManager.Instance.SelectNextOption();

                 else if (Keyboard.current.fKey.wasPressedThisFrame)
                    ConversationManager.Instance.PressSelectedOption();
             }
        }
    }
}
