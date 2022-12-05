using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyMovement _enemyMovement;
    private float _spawnInvincibilityTime = 1.5f;
    public bool isInvincible = true;

    private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBar _healthBar;

    public float MoveSpeed;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _enemyMovement = new EnemyMovement(this);
        StartCoroutine(SpawnInvincibility());
        _healthBar.UpdateHealth(_maxHealth, _currentHealth);
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
        get { return _currentHealth; }
        set 
        {
            if (value <= 0)
                Destroy(gameObject);
            else
            {
                if (!isInvincible)
                {
                    _currentHealth = value;
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        _healthBar.UpdateHealth(_maxHealth, Health);
    }

    private IEnumerator SpawnInvincibility()
    {
        yield return new WaitForSeconds(_spawnInvincibilityTime);
        isInvincible = false;
    }
}
