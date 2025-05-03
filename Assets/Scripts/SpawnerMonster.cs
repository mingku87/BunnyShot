public class SpawnerMonster : Spawner
{
    void Start()
    {
        coolTimeMax = GameConstant.monsterSpawnTime[GameManager.round];
    }
}