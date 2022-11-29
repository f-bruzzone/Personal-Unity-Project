using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float lifespan = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLife());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnLife()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
