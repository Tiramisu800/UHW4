using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlyUsual : Enemy
{
    private void Update()
    {
        base._agent.speed = _agent.acceleration * _agent.speed / 3;
    }
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

}
