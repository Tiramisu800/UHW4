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
            EnemyFactory<EnemySoliderFast> goblinSFactory = new EnemyFactory<EnemySoliderFast>();
            return goblinSFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemySolider> goblinUFactory = new EnemyFactory<EnemySolider>();
            return goblinUFactory.CreateEnemy(data);
        }
    }

    public class OrcTankFactory : Factory
    {
        public override Enemy CreateSpecialEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyTankMobile> tankSFactory = new EnemyFactory<EnemyTankMobile>();
            return tankSFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyTankHard> tankUFactory = new EnemyFactory<EnemyTankHard>();
            return tankUFactory.CreateEnemy(data);
        }

    }

    public class MigoFlyFactory : Factory
    {
        public override Enemy CreateSpecialEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyFlyAttacker> flySFactory = new EnemyFactory<EnemyFlyAttacker>();
            return flySFactory.CreateEnemy(data);
        }

        public override Enemy CreateUsualEnemyClass(EnemyData data)
        {
            EnemyFactory<EnemyFlyUsual> flyUFactory = new EnemyFactory<EnemyFlyUsual>();
            return flyUFactory.CreateEnemy(data);
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

