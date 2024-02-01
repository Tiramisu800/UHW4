using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    GoblinUsual,
    GoblinSpecial,
    OrcTankUsual,
    OrcTankSpecial,
    FlyMigoUsual,
    FlyMigoSpecial
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "TD/CreateEnemys")]
public class EnemyData : ScriptableObject
{
    //public List<GameObject> Prefabs;
    public GameObject Prefab;
    public EnemyType Type;
}
