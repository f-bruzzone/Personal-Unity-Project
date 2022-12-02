using System.Collections;
using UnityEngine;

public class PowerUpFireRate : PowerUp, IPowerUp
{
    private float _powerUpDuration = 12.0f;
    private float _fireRateIncrease = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnLife());
    }
    public float PowerUpDuration
    {
        get { return _powerUpDuration; }
        set { _powerUpDuration= value; }
    }

    public void PowerUp(PlayerController player)
    {
        player.FireRate /= _fireRateIncrease;
        Destroy(gameObject);
        StartCoroutine(Duration(player));
    }

    public IEnumerator Duration(PlayerController player)
    {
        yield return new WaitForSeconds(_powerUpDuration);
        player.FireRate *= _fireRateIncrease;
    }
}
