using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBuy : MonoBehaviour
{
    private PlayerControlActions playerAction;
    public event Action BuyItemEvent;
    private bool wantBuy = false;

    void Awake()
    {
        playerAction = new PlayerControlActions();
    }

    private void BuyItem(InputAction.CallbackContext obj)
    {
        if(wantBuy)
            BuyItemEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
            wantBuy = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
            wantBuy = false;
    }

    private void OnEnable()
    {
        playerAction.Player.Enable();
        playerAction.Player.Buy.started += BuyItem;
    }

    private void OnDisable()
    {
        playerAction.Player.Buy.started -= BuyItem;
        playerAction.Player.Disable();
    }
}
