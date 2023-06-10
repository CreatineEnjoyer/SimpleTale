using UnityEngine;

public class PlayerPickupMoney : MonoBehaviour
{
    [SerializeField] private MoneyScriptable playerMoney;
    [SerializeField] private AudioSource coinAudio;

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Coin"))
            {
                playerMoney.Money++;
                Destroy(collision.gameObject);
                coinAudio.Play();
        }
    }
}
