using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerPickupMoney : MonoBehaviour
{
    //[SerializeField] private MoneyScriptable playerMoney;

    [SerializeField]
    private int money;


    void Start()
    {
        //money = playerMoney.Money;
    }

    private void OnColisionEnter2D(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Coin"))
            {
                money++;
                Destroy(collision.gameObject);
            }
    }


}
