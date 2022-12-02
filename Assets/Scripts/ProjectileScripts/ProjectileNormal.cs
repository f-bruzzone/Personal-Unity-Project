using UnityEngine;

public class ProjectileNormal: MonoBehaviour
{
	public float Speed = 50.0f;
	private float _damage = 25.0f;

	private ProjectileMovement _projectileMovement;

	public ProjectileNormal()
	{
		_projectileMovement = new ProjectileMovement(this);
	}

	private void Start()
	{
		_projectileMovement.GetDirection();
	}

	private void Update()
	{
		_projectileMovement.Travel();
	}

	public void DestroySelf()
	{
		Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
			var enemy = collision.collider.GetComponent<Enemy>();
			enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
