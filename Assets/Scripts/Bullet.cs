public class Bullet : EnemyObject
{
    void Start()
    {
        vel = transform.forward * GameConstant.bulletSpeed[GameManager.round];
        Destroy(gameObject, GameConstant.bulletTime[GameManager.round]);
    }
}
