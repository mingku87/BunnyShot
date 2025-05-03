public class SpawnerBullet : Spawner
{
    void Start()
    {
        coolTimeMax = GameConstant.bulletSpawnTime[GameManager.round];
    }
}