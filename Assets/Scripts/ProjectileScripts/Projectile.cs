using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Vector3 _initialAngle;

    private Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _destructionAnimationPrefab;

    private void Start()
    {
        _initialAngle = Vector3.up;
        GetDirection();
        GetRotation();
    }


    private void Update()
    {
        if (_direction != Vector3.zero)
            Travel();
        else
        {
            GetDirection();
            GetRotation();
        }
    }

    private void OnDisable()
    {
        transform.position = Vector3.zero;
        _direction = Vector3.zero;
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            Instantiate(_destructionAnimationPrefab, transform.position, Quaternion.identity);
            enemy.TakeDamage(_damage);
            ProjectileObjectPool._pool.Release(this);
        }
    }

    protected void Travel()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        DestroyOutOfBounds();
    }

    protected void GetDirection()
    {
        // Converts the mouse position from pixels to the in-game coords
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 3;

        _direction = (mousePos - transform.position).normalized;
    }

    protected void DestroyOutOfBounds()
    {
        if (transform.position.y > 30 || transform.position.y < 0 ||
           transform.position.x > 45 || transform.position.x < -45)
        {
            ProjectileObjectPool._pool.Release(this);
        }
    }
    private void GetRotation()
    {
        var angle = Vector3.Angle(_initialAngle, _direction);

        if(_direction.x < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, -1));
    }
}
