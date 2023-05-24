using UnityEngine;
using UnityEngine.Tilemaps;

public class BossArea : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TilemapRenderer>().enabled = false;
        GetComponent<TilemapCollider2D>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && GetComponent<TilemapRenderer>().enabled == false)
        {
            GetComponent<TilemapRenderer>().enabled = true;
            GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
