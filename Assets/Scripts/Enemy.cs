using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public event Action<float> OnEnemyKilled;

    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _moveTarget;
    [SerializeField] protected Image _healthBar; 
    [SerializeField] protected float _health;

    protected float _maxHealth;

    public float WaveCost { get; internal set; }

    private void OnEnable()
    {
        _maxHealth = _health;
    }

    public void SetDestination(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }

    public virtual void TakeDamage(float dmg)
    {
        _health -= dmg;

        _healthBar.fillAmount = _health / _maxHealth;

        if (_health <= 0)
        {
            gameObject.SetActive(false);
            OnEnemyKilled?.Invoke(WaveCost);
        }
    }

    private void Update()
    {
        Vector3 dir = Camera.main.transform.position - _healthBar.GetComponentInParent<Canvas>().transform.position;
        dir.x = 0;
        dir.y = 0;
        dir.z = 0;
        _healthBar.GetComponentInParent<Canvas>().transform.rotation = Quaternion.LookRotation(dir);
    }
}

public interface IEnemy
{
    event Action<float> OnEnemyKilled;
    void TakeDamage(float dmg);
}