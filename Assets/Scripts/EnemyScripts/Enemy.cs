using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyMovement _enemyMovement;

    [SerializeField] private float _health = 100.0f;

    public float MoveSpeed;

    private void Start()
    {
        _enemyMovement = new EnemyMovement(this);
    }

    private void Update()
    {
        _enemyMovement.Tick();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public float Health
    {
        get { return _health; }
        set 
        {
            if (value <= 0)
                Destroy(gameObject);
            else
            {
                _health = value;
                print("health value changed");
                print(_health);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
