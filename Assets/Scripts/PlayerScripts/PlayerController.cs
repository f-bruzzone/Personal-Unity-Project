using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private PlayerMovement _playerMovement;
    private PlayerAction _playerAction;

    private float _health;
    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }

    [Header("Movement Properties")]
    public float MoveSpeed = 20.0f;

    [Header("Firing Properties")]
    public GameObject ProjectilePrefab;
    [SerializeField] private float _fireRate = 0.3f;

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


    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.GetComponent<IPowerUp>() != null)
        {
            var powerUp = other.GetComponent<IPowerUp>();
            powerUp.PowerUp(this);
            Destroy(other.gameObject);
        }
    }
}
