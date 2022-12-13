using UnityEngine;

public class EnemyProjectile : Projectile
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerController>())
        {
            Instantiate(_destructionAnimationPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Instantiate(_destructionAnimationPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected override void GetDirection()
    {
        Direction = (FindObjectOfType<PlayerController>().transform.position - transform.position).normalized; 
    }
}
