using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float moveSpeed = 20.0f;

    [Header("Firing Properties")]
    public float fireRate = 0.3f;
    public GameObject projectilePrefab;

    [Header("Powerup Properties")]
    public float powerupDuration = 12.0f;

    [Header("Turret Properties")]
    public Transform head;
    public Transform turret;

    [Header("Effects")]
    public ParticleSystem firingAnim;

    private float turretRotation;
    private float headRotation;
    private float headRotationSpeed = 10.0f;
    private float projectileSpawnOffset = 1.5f;
    private bool canFire = true;
    private float sideBound = 31.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        BoundPlayer();
        PlayerFire();
        MoveHead();
        MoveTurret();
    }

    // move the player
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
    }

    // prevent player from moving out of bounds
    void BoundPlayer()
    {
        if (transform.position.x < -sideBound)
        {
            transform.position = new Vector3(-sideBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > sideBound)
        {
            transform.position = new Vector3(sideBound, transform.position.y, transform.position.z);
        }
    }

    void PlayerFire()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && canFire)
        {
            StartCoroutine(FireRate());
        }
    }
    void FireProjectile()
    {
        Vector3 spawnPosition = new Vector3(turret.position.x, turret.position.y + projectileSpawnOffset, turret.position.z);
        Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
        firingAnim.Play();
    }

    IEnumerator FireRate()
    {
        canFire = false;
        FireProjectile();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            fireRate /= 3;
            Destroy(other.gameObject);
            StartCoroutine(PowerUp());
        }
    }

    IEnumerator PowerUp()
    {
        yield return new WaitForSeconds(powerupDuration);
        fireRate *= 3;
    }

    void MoveHead()
    {
        headRotation += Input.GetAxis("Mouse X") * -headRotationSpeed;
        headRotation = Mathf.Clamp(headRotation, 0, 180);
        head.localRotation = Quaternion.AngleAxis(headRotation, Vector3.up);
    }
    
    void MoveTurret()
    {
        turretRotation += Input.GetAxis("Mouse Y");
        turretRotation = Mathf.Clamp(turretRotation, 0, 180);
        turret.localRotation = Quaternion.AngleAxis(turretRotation, Vector3.left);
    }
}
