using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float bounds = 40.0f;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyOutOfBounds();
    }

    private void Move()
    {
        gameObject.transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.x <= -bounds || transform.position.x >= bounds)
        {
            Destroy(gameObject);
        }
    }
}
