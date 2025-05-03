using UnityEngine;

public class Monster : EnemyObject
{
    public GameObject shieldPrefab;
    public GameObject portionPrefab;
    public GameObject boosterPrefab;
    public GameObject clockPrefab;

    void Start()
    {
        float randomX = Random.Range(-1.0f, 0f);
        Vector3 randomDir = new Vector3(randomX, 0, -Mathf.Sqrt(1 - (randomX * randomX)));
        vel = randomDir * GameConstant.monsterSpeed[GameManager.round];

        Destroy(gameObject, 7.0f);
    }

    public void Die()
    {
        Player.Instance.KillCount();
        DropItem();
        Destroy(gameObject);
    }

    private void DropItem()
    {
        int itemDrop = Random.Range(0, 100);
        GameObject prefab = itemDrop < 10 ? shieldPrefab : itemDrop < 15 ? portionPrefab : itemDrop < 25 ? boosterPrefab : itemDrop < 35 ? clockPrefab : null;
        if (prefab == null) return;
        Instantiate(prefab, transform.position + new Vector3(0, 1, 0), prefab.transform.rotation);
    }
}