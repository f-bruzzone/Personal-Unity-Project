using UnityEngine;

public class ProjectileMovement
{
    private float _speed;
    private Vector3 _direction;
    private ProjectileNormal _projectileNormal;

    public ProjectileMovement(ProjectileNormal projectile)
    {
        _projectileNormal = projectile;
        _speed = projectile.Speed;
    }

    public void Travel()
    {
        _projectileNormal.transform.Translate(_direction * _speed * Time.deltaTime);
        DestroyOutOfBounds();
    }

    public void GetDirection()
    {
        // Converts the mouse position from pixels to the in-game coords
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 3;

        _direction = (mousePos - _projectileNormal.transform.position).normalized;
    }

    private void DestroyOutOfBounds()
    {
        if(_projectileNormal.transform.position.y > 30 || _projectileNormal.transform.position.y < 0 ||
           _projectileNormal.transform.position.x > 45 || _projectileNormal.transform.position.x < -45)
        {
            _projectileNormal.DestroySelf();
        }
    }

}
