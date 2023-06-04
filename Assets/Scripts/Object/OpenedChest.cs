using UnityEngine;

public class OpenedChest : MonoBehaviour
{
    [SerializeField] Sprite openedChest;
    private ITakeDamage health;

    [SerializeField] private GameObject chestItem;

    void Start()
    {
        health = GetComponent<ITakeDamage>();
        health.DeathEvent += OpenChest;
    }

    private void OpenChest()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
        Instantiate(chestItem, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), Quaternion.identity);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private void OnDisable()
    {
        health.DeathEvent -= OpenChest;
    }
}
