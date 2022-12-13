using UnityEngine;

public class ProjectileNormal: Projectile
{
    private void Update()
    {
        if (Direction != Vector3.zero)
            Travel();
        else
        {
            GetDirection();
            GetRotation(Direction);
        }

        if (DetermineOutOfBounds())
            DestroyOutOfBounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            Instantiate(_destructionAnimationPrefab, transform.position, Quaternion.identity);
            enemy.TakeDamage(Damage);
            ProjectileObjectPool.Pool.Release(this);
        }
    }

    private void DestroyOutOfBounds()
    {
        ProjectileObjectPool.Pool.Release(this);
    }
}
