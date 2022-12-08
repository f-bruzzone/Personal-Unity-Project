using UnityEngine;
using UnityEngine.Pool;

public class ProjectileObjectPool: MonoBehaviour
{
	[SerializeField] private Projectile _projectile;

    public static IObjectPool<Projectile> _pool;

	private void Start()
	{
		_pool = new ObjectPool<Projectile>(CreateProjectile, TakeFromPool, ReturnToPool, RemoveFromPool, false, 30, 50);
	}

	private Projectile CreateProjectile()
	{
		return Object.Instantiate(_projectile);
	}

	private void TakeFromPool(Projectile projectile)
	{
		projectile.GetComponent<Projectile>().Damage = _projectile.Damage;
		projectile.gameObject.SetActive(true);
	}

	private void ReturnToPool(Projectile projectile)
	{
        projectile.gameObject.SetActive(false);
    }

	private void RemoveFromPool(Projectile projectile)
	{
		Object.Destroy(projectile);
	}
}
