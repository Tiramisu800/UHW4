using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankHard : Enemy
{
    private float _defence = 100;
    private void Update()
    {
        base._maxHealth += _defence;
    }
}
