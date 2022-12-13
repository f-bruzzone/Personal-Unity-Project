using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _spawnInvincibilityTime;
    [SerializeField] private EnemyProjectile _projectile;
    [SerializeField] private float _initialAttackDelay;

    private float _currentHealth;
    private EnemyMovement _enemyMovement;
    private bool isInvincible = true;

    public float MoveSpeed;


    private void Start()
    {
        _currentHealth = _maxHealth;
        _enemyMovement = new EnemyMovement(this);
        StartCoroutine(SpawnInvincibility());
        _healthBar.UpdateHealth(_maxHealth, _currentHealth);
        StartCoroutine(InitialAttack());
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
                   _currentHealth = value;
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

    private IEnumerator Attack()
    {
        Instantiate(_projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Attack());
    }

    private IEnumerator InitialAttack()
    {
        yield return new WaitForSeconds(_initialAttackDelay);
        StartCoroutine(Attack());
    }
}
