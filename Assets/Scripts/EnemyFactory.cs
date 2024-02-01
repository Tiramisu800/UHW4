using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Abstract.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Factory
    {
        public abstract Enemy CreateSpecialEnemyClass(EnemyData data);
        public abstract Enemy CreateUsualEnemyClass(EnemyData data);

    }

    public class GoblinSoliderFactory : Factory
    {

        public override Enemy CreateSpecialEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemySoliderFast> goblinFactory = new EnemyFactory<EnemySoliderFast>();
            return goblinFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemySolider> goblinFactory = new EnemyFactory<EnemySolider>();
            return goblinFactory.CreateEnemy(data);
           
            /*
            Enemy goblin = new EnemySolider();
            GameObject obj = GameObject.Instantiate(goblin.gameObject);
            var enemy = obj.GetComponent<Enemy>();
            return enemy;
            */
        }
    }

    public class OrcTankFactory : Factory
    {
        public override Enemy CreateSpecialEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyTankMobile> goblinFactory = new EnemyFactory<EnemyTankMobile>();
            return goblinFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyTankHard> goblinFactory = new EnemyFactory<EnemyTankHard>();
            return goblinFactory.CreateEnemy(data);
        }

    }

    public class MigoFlyFactory : Factory
    {
        public override Enemy CreateSpecialEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyFlyAttacker> goblinFactory = new EnemyFactory<EnemyFlyAttacker>();
            return goblinFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyFlyUsual> goblinFactory = new EnemyFactory<EnemyFlyUsual>();
            return goblinFactory.CreateEnemy(data);
        }
    }

    
}


    public class EnemyFactory<T> where T : Enemy
    {
        /// <summary>
        /// try "CreateEnemy" method but with List of Enemy prefabs
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /*
        public T CreateEnemy(EnemyData data)
        {
            List<T> enemies = new List<T>();
            foreach (GameObject prefab in data.Prefabs)
            {
                GameObject instance = GameObject.Instantiate(prefab);
                T enemy = instance.GetComponent<T>();
                enemies.Add(enemy);
            }
            return enemies;
        }
        */

        public T CreateEnemy(EnemyData data)
        {
            GameObject instance = GameObject.Instantiate(data.Prefab);
            T enemy = instance.GetComponent<T>();
            return enemy;
        }

    }

