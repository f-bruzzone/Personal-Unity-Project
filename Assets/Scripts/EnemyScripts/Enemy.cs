using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyMovement _enemyMovement;
    [SerializeField] private float Health;

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

    public void TakeDamage()
    {

    }
}
