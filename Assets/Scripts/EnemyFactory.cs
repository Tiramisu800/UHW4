using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Reflection;

namespace Assets.Scripts
{
    public abstract class Factory
    {
        public abstract Enemy CreateFastEnemyClass();
        public abstract Enemy CreateUsualEnemyClass();
    }

    public class GoblinSoliderFactory : Factory
    {
        
        public override Enemy CreateFastEnemyClass()
        {
            return new EnemySoliderFast();
        }

        public EnemySoliderSlow enemySoliderSlowPrefab;
        public override Enemy CreateUsualEnemyClass()
        {
            //return new EnemySoliderSlow();
            return Object.Instantiate(enemySoliderSlowPrefab);
        }
    }

    public class OrcTankFactory : Factory
    {
        public override Enemy CreateFastEnemyClass()
        {
            return new EnemyTankMobile();
        }

        public override Enemy CreateUsualEnemyClass()
        {
            return new EnemyTankHard();
        }
    }

    public class MigoFlyFactory : Factory
    {
        public override Enemy CreateFastEnemyClass()
        {
            return new EnemyFlyAttacker();
        }

        public override Enemy CreateUsualEnemyClass()
        {
            return new EnemyFlyUsual();
        }
    }
}

public enum EnemyType
{
    Goblin,
    OrcTank,
    FlyMigo
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "TD/CreateEnemys")]
public class EnemyFactory : ScriptableObject
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
        /*
        if (index % 3 == 1)
        {
            Enemies[index].Factory = new MigoFlyFactory();
        }
        else if (index % 3 == 2)
        {
            Enemies[index].Factory = new OrcTankFactory();
        }
        else if (index % 3 == 0)
        {
            Enemies[index].Factory = new GoblinSoliderFactory();
        }

        if (index % 2 == 1)
        {
            Enemies[index].Enemy = Enemies[index].Factory.CreateUsualEnemyClass();
        }
        else if (index % 2 == 0)
        {
            Enemies[index].Enemy = Enemies[index].Factory.CreateFastEnemyClass();
        }
        */

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
    //public Factory Factory;
} 

/*
public class WaveInfo
{

    public Enemy Enemy { get; set; }
    public float WaveDeley { get; set; }
    public float EnemyCost { get; set; }
    public WaveInfo(Enemy enemy, float waveDeley, float enemyCost) 
    {
        Enemy = enemy;
        WaveDeley = waveDeley;
        EnemyCost =  enemyCost;
    }

    public WaveInfo() { }
}
*/

/*
public class EnemyFactory
{

}
*/