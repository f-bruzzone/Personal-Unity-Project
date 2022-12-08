using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUp, IPowerUp
{
    [SerializeField] private float _duration;
    [SerializeField] private float _damageInc;

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
        var projectile = player.ProjectilePrefab.GetComponent<Projectile>();
        projectile.Damage *= _damageInc;
    }

    public IEnumerator Duration(PlayerController player)
    {
        yield return new WaitForSeconds(_duration);
        var projectile = player.ProjectilePrefab.GetComponent<Projectile>();
        projectile.Damage /= _damageInc;
    }

}
