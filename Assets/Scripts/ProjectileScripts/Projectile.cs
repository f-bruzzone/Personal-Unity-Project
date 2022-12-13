using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Vector3 _initialAngle;

    private Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] protected GameObject _destructionAnimationPrefab;

    private void Start()
    {
        _initialAngle = Vector3.up;
        GetDirection();
        GetRotation(_direction);
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
    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    protected void Travel()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    protected virtual void GetDirection()
    {
        // Converts the mouse position from pixels to the in-game coords
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 3;

        _direction = (mousePos - transform.position).normalized;
    }

    protected bool DetermineOutOfBounds()
    {
        return (transform.position.y > 30 || transform.position.y < 0 ||
           transform.position.x > 45 || transform.position.x < -45);
    }
    protected void GetRotation(Vector3 direction)
    {
        var angle = Vector3.Angle(_initialAngle, direction);

        if(_direction.x < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, -1));
    }
}
