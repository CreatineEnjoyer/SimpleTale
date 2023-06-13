using DialogueEditor;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] private GameObject finalBossHealth;
    [SerializeField] private AudioSource bossMusic;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wizard;
    private CharacterDeath bossDeath;

    private void Start()
    {
        bossDeath = GetComponentInChildren<CharacterDeath>();
        bossDeath.BossDeathEvent += Defeat;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            backgroundMusic.Stop();
            bossMusic.Play();
            ConversationManager.OnConversationEnded += ActivateBoss;
        }
    }

    private void Defeat()
    {
        finalBossHealth.SetActive(false);
        backgroundMusic.Play();
        bossMusic.Stop();
    }

    private void OnDisable()
    {
        bossDeath.BossDeathEvent -= Defeat;
        ConversationManager.OnConversationEnded -= ActivateBoss;
    }

    private void ActivateBoss()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        wall.SetActive(false);
        finalBossHealth.SetActive(true);
        wizard.SetActive(false);
    }
}
