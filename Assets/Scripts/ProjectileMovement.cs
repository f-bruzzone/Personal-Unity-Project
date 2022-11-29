using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        GetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
        DestroyOutOfBounds();
    }

    private void GetDirection()
    {
        // Converts the mouse position from pixels to the in-game coords
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 3;

        direction = (mousePos - transform.position).normalized;
    }

    private void DestroyOutOfBounds()
    {
        if(transform.position.y > 30 || transform.position.y < 0 ||
           transform.position.x > 45 || transform.position.x < -45)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
