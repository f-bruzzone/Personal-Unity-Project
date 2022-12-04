using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;

    /*public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }*/

    private void Start()
    {
        GetDirection();
    }

    private void Update()
    {
        Travel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    protected void Travel()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
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
            Destroy(gameObject);
        }
    }
}
