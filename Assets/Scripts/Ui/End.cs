using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        endCanvas.SetActive(true);
        player.SetActive(false);
    }
}
