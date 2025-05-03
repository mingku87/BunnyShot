using UnityEngine;

public enum ItemType
{
    Shield,
    Portion,
    Booster,
    Clock
}

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;

    void Start()
    {
        Destroy(gameObject, GameConstant.itemTime[GameManager.round]);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetItem(itemType);
            Destroy(gameObject);
        }
    }
}