using UnityEngine;

// 22.05.19
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    protected Transform target => Player.Instance.transform;
    protected float coolTime;
    protected float coolTimeMax;

    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        if (coolTime < coolTimeMax)
        {
            coolTime += Time.deltaTime;
            return;
        }

        coolTime = 0;
        Spawn();
    }

    private void Spawn()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        go.transform.LookAt(target);
    }
}