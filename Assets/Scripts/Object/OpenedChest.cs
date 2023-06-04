using UnityEngine;

public class OpenedChest : MonoBehaviour
{
    [SerializeField] Sprite openedChest;
    private ITakeDamage health;

    void Start()
    {
        health = GetComponent<ITakeDamage>();
        health.DeathEvent += OpenChest;
    }

    private void OpenChest()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
    }

    private void OnDisable()
    {
        health.DeathEvent -= OpenChest;
    }
}
