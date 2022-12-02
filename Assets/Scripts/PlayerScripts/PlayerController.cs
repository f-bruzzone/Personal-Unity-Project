using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private PlayerMovement _playerMovement;
    private PlayerAction _playerAction;

    private float _health;

    [Header("Movement Properties")]
    public float MoveSpeed = 20.0f;

    [Header("Firing Properties")]
    public float FireRate = 0.3f;
    public GameObject ProjectilePrefab;

    [Header("Powerup Properties")]
    public float powerupDuration = 12.0f;

    [Header("Turret Properties")]
    public Transform Head;
    public Transform Turret;

    [Header("Effects")]
    public ParticleSystem FiringAnim;

    private void Start()
    {
        _playerMovement = new PlayerMovement(this);
        _playerAction = new PlayerAction(this);
    }

    void Update()
    {
        _playerMovement.MovePlayer();
        _playerMovement.BoundPlayer();
        _playerMovement.HeadMovement();
        _playerAction.PlayerFire();
    }

    public void TakeDamage(float damage)
    {

    }

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    //Powerup methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            FireRate *= 0.333333f;
            Destroy(other.gameObject);
            StartCoroutine(PowerUp());
        }
    }

    IEnumerator PowerUp()
    {
        yield return new WaitForSeconds(powerupDuration);
        FireRate *= 3;
    }
}
