using System.Collections.Generic;

public static class GameConstant
{
    public static List<float> bulletSpawnTime = new() { 0, 3, 3, 2, 2, 2 };
    public static List<float> bulletTime = new() { 0, 5, 6, 7, 8, 9 };
    public static List<float> bulletSpeed = new() { 0, 8, 10, 12, 14, 16 };
    public static List<int> killMonsterMax = new() { 0, 20, 40, 60, 80, 100 };
    public static List<float> monsterSpeed = new() { 0, 5, 6, 7, 8, 9 };
    public static List<float> monsterSpawnTime = new() { 0, 2, 1.8f, 1.5f, 1.2f, 1 };
    public static List<float> itemTime = new() { 0, 10, 9, 8, 7, 6 };
}