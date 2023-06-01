using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickupPotions : MonoBehaviour
{
    public GameObject potionIcon1;
    public GameObject potionIcon2;
    public GameObject potionIcon3;
    public GameObject potionIcon4;
    public GameObject potionIcon5;
    public GameObject potionIcon6;
    public GameObject potionIcon7;

    

    [SerializeField]
    private int potions;

    [SerializeField]
    private InputAction usePotion;
    private PlayerControlActions playerAction;

    private void Awake()
    {
        playerAction = new PlayerControlActions();
    }

    private void OnEnable()
    {
        usePotion = playerAction.Player.UsePotion;
        usePotion.Enable();

        usePotion.performed += UsePotion;
    }

    private void OnDisable()
    {
        usePotion.Disable();
    }

    private void UsePotion(InputAction.CallbackContext context)
    {
        if (potions > 0)
        {
            potions = potions - 1;

            UpdatePotionsCount();

            GetComponent<ITakeDamage>().TakeDamage(-25);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            potions++;
            Destroy(collision.gameObject);
            UpdatePotionsCount();
        }
    }

    void UpdatePotionsCount()
    {
        switch (potions)
        {
            case 0:
                potionIcon1.SetActive(false);
                break;

            case 1:
                potionIcon1.SetActive(true);
                potionIcon2.SetActive(false);
                break;

            case 2:
                potionIcon2.SetActive(true);
                potionIcon3.SetActive(false);
                break;

            case 3:
                potionIcon3.SetActive(true);
                potionIcon4.SetActive(false);
                break;

            case 4:
                potionIcon4.SetActive(true);
                potionIcon5.SetActive(false);
                break;

            case 5:
                potionIcon5.SetActive(true);
                potionIcon6.SetActive(false);
                break;

            case 6:
                potionIcon6.SetActive(true);
                potionIcon7.SetActive(false);
                break;

            case >= 7:
                potionIcon7.SetActive(true);
                break;
        }

    }
}
