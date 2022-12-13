using UnityEngine;
using UnityEngine.Pool;

public class ProjectileObjectPool: MonoBehaviour
{
	[SerializeField] private ProjectileNormal _projectile;

    public static IObjectPool<ProjectileNormal> Pool;

	private void Start()
	{
		Pool = new ObjectPool<ProjectileNormal>(CreateProjectile, TakeFromPool, ReturnToPool, RemoveFromPool, false, 30, 50);
	}

	private ProjectileNormal CreateProjectile()
	{
		return Object.Instantiate(_projectile);
	}

	private void TakeFromPool(ProjectileNormal projectile)
	{
		projectile.GetComponent<ProjectileNormal>().Damage = _projectile.Damage;
		projectile.gameObject.SetActive(true);
	}

	private void ReturnToPool(ProjectileNormal projectile)
	{
        projectile.gameObject.SetActive(false);
    }

	private void RemoveFromPool(ProjectileNormal projectile)
	{
		Object.Destroy(projectile);
	}
}
