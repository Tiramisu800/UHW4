using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySoliderSlow : Enemy
{
    private void Update()
    {
        base._agent.speed = 0.8f;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
}
