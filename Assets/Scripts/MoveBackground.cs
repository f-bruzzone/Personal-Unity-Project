using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private Vector3 startPos;
    private float repeatWidth;
   
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;

        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
