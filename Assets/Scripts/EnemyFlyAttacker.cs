using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyAttacker : Enemy
{
    [SerializeField] private Transform _target;

    public float _attackRange = 2;


    private void Update()
    {
        FindClosestTarget();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

    /// <summary>
    /// Try to make able to attack turretes 
    /// </summary>
    private void FindClosestTarget()
    {
        if (EnemyManager.Instance == null) return;

        if (_target)
        {
            if (!_target.gameObject.activeSelf)
            {
                _target = null;
            }
            else
            {
                var dis = (_target.position - transform.position).magnitude;

                if (dis <= _attackRange)
                {
                    _target.gameObject.SetActive(false);
                }
                else
                {
                    _target = null;
                }
            }
        }

        List<Turrete> targets = new List<Turrete>();
        foreach (var enemy in targets)
        {
            if (!_target)
            {
                if (enemy.gameObject.activeSelf)
                {
                    var dis = (enemy.transform.position - transform.position).magnitude;

                    if (dis < _attackRange)
                    {
                        _target = enemy.transform;
                    }
                }
            }
        }

        if (!_target) return;

    }
}
