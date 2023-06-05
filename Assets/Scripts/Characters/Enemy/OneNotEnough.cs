using System;
using UnityEngine;

public class OneNotEnough : MonoBehaviour
{
    [SerializeField] private GameObject ninja;
    [SerializeField] private GameObject firstNinja;
    [SerializeField] private GameObject secondNinja;

    private CharacterDeath bossDeath;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        bossDeath = ninja.GetComponent<CharacterDeath>();
        bossDeath.BossDeathEvent += WizardDialogue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke(nameof(SpawnTwoNinjas), 5f);
    }

    private void WizardDialogue()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void SpawnTwoNinjas()
    {
        firstNinja.SetActive(true);
        secondNinja.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        bossDeath.BossDeathEvent -= WizardDialogue;
    }
}
