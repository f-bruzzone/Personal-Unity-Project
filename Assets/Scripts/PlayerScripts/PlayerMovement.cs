using UnityEngine;

public class PlayerMovement
{
    private Transform _transform;
    private float _moveSpeed;
    private readonly float _sideBound = 31.75f;


    private Transform _head;
    private Transform _turret;
    private float _headRotation;
    private readonly float _headRotationSpeed = 10.0f;
    private float _turretRotation;

    public PlayerMovement(PlayerController playerController)
    {
        _moveSpeed = playerController.MoveSpeed;
        _transform = playerController.transform;
        _head = playerController.Head;
        _turret = playerController.Turret;
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * horizontalInput);
    }

    public void BoundPlayer()
    {
        if (_transform.position.x < -_sideBound)
        {
            _transform.position = new Vector3(-_sideBound, _transform.position.y, _transform.position.z);
        }
        if (_transform.position.x > _sideBound)
        {
            _transform.position = new Vector3(_sideBound, _transform.position.y, _transform.position.z);
        }
    }

    public void HeadMovement()
    {
        MoveHead();
        MoveTurret();
    }

    private void MoveHead()
    {
        _headRotation += Input.GetAxis("Mouse X") * -_headRotationSpeed;
        _headRotation = Mathf.Clamp(_headRotation, 0, 180);
        _head.localRotation = Quaternion.AngleAxis(_headRotation, Vector3.up);
    }

    private void MoveTurret()
    {
        _turretRotation += Input.GetAxis("Mouse Y");
        _turretRotation = Mathf.Clamp(_turretRotation, 0, 180);
        _turret.localRotation = Quaternion.AngleAxis(_turretRotation, Vector3.left);
    }
}
