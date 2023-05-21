using UnityEngine;

public class SecretArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
            gameObject.SetActive(false);
    }
}
