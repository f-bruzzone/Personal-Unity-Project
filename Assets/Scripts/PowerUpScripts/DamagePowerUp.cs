using System.Collections;
using UnityEngine;

public class DamagePowerUp : PowerUp, IPowerUp
{
    [SerializeField] private float _duration;
    [SerializeField] private float _damageInc;

    [Header("Projectile Damage Increase")]
    [SerializeField] private ProjectileNormal _projectile;

    void Start()
    {
        StartCoroutine(SpawnLife());
    }

    public float PowerUpDuration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public void PowerUp(PlayerController player)
    {
        _projectile.Damage *= _damageInc;
    }

    public IEnumerator Duration(PlayerController player)
    {
        yield return new WaitForSeconds(_duration);
        _projectile.Damage /= _damageInc;
    }

}
