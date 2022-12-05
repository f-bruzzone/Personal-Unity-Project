using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyMovement _enemyMovement;
    private float _spawnInvincibilityTime = 1.5f;
    public bool isInvincible = true;

    [SerializeField] private float _health = 100.0f;

    public float MoveSpeed;

    private void Start()
    {
        _enemyMovement = new EnemyMovement(this);
        StartCoroutine(SpawnInvincibility());
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
                if (!isInvincible)
                {
                    _health = value;
                    print("health value changed");
                    print(_health);
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private IEnumerator SpawnInvincibility()
    {
        yield return new WaitForSeconds(_spawnInvincibilityTime);
        isInvincible = false;
    }
}
