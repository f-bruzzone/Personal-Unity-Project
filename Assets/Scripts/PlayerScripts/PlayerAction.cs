using System.Collections;
using UnityEngine;

public class PlayerAction
{
    private PlayerController _playerController;
    private Transform _turret;
    private GameObject _projectilePrefab;
    private readonly float _projectileSpawnOffset = 1.5f;
    private readonly ParticleSystem _firingAnim;
    private bool _canFire = true;

    public PlayerAction(PlayerController playerController)
	{
		_playerController = playerController;
        _turret = playerController.Turret;
        _projectilePrefab = playerController.ProjectilePrefab;
        _firingAnim = playerController.FiringAnim;
    }

    public void PlayerFire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _canFire)
        {
            _playerController.StartCoroutine(FireRate(_playerController.FireRate));
        }
    }

    IEnumerator FireRate(float fireRate)
    {
        _canFire = false;
        FireProjectile();
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }

    private void FireProjectile()
    {
        Vector3 spawnPosition = new Vector3(_turret.position.x, _turret.position.y + _projectileSpawnOffset, _turret.position.z);
        var projectile = ProjectileObjectPool._pool.Get();
        projectile.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        //GameObject.Instantiate(_projectilePrefab, spawnPosition, _projectilePrefab.transform.rotation);
        _firingAnim.Play();
    }
}
