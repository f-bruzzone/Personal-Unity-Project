using UnityEngine;

public class EnemyMovement
{
    private readonly float _speed;

    private Enemy _enemy;

    private readonly float _bounds = 40.0f;
    private readonly Vector3 _moveDirection;
    private bool _isFromLeft;


    public EnemyMovement(Enemy enemy)
    {
        _enemy = enemy;
        _moveDirection = Vector3.right;
        _speed = enemy.MoveSpeed;
        WhereToDestroy(_enemy.transform.position.x);
    }

    public void Tick()
    {
        Move();
        DestroyOutOfBounds();
    }

    private void Move()
    {
        _enemy.transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void DestroyOutOfBounds()
    {
        if (_isFromLeft && _enemy.transform.position.x > _bounds)
        {
            _enemy.DestroySelf();
        }
        else if (!_isFromLeft && _enemy.transform.position.x < -_bounds)
        {
            _enemy.DestroySelf();
        }
    }

    private void WhereToDestroy(float spawnLocation)
    {
        if(spawnLocation <= -_bounds)
        {
            _isFromLeft = true;
        }
        else
        {
            _isFromLeft = false;
        }
    }
}
