using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMobile : Enemy
{
    private float _defence = 10f;
    private void Update()
    {
        base._agent.speed = 1.1f;
        base._maxHealth += _defence;
    }

}