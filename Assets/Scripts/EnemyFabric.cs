using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Bob,
    Ken
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "TD/CreateEnemys")]
public class EnemyFabric : ScriptableObject
{
    public List<WaveInfo> Enemies = new List<WaveInfo>();

    public T CreateEnemy<T>(EnemyType enemy) where T : Enemy
    {
        var enemyFabric = Enemies.Find(x => x.EnemyType == enemy);

        if (enemyFabric != null)
        {
            return Instantiate(enemyFabric.Enemy) as T;
        }

        return default;
    }

    public WaveInfo GetNextWave(int index)
    {
        try
        {
            return Enemies[index];
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }

    public Enemy SpawnEnemy(int index)
    {
        return Instantiate(Enemies[index].Enemy);
    }
}

[Serializable]
public class WaveInfo
{
    public Enemy Enemy;
    public float WaveDeley;
    public float EnemyCost;
    public EnemyType EnemyType;
}