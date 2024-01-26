using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySoliderFast : Enemy
{
    private void Update()
    {
        base._agent.speed = 1;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
}
