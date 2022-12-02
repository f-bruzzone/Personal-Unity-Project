using System.Collections;
using UnityEngine;

public class PowerUp: MonoBehaviour
{
    private float _lifespan = 7.0f;

    public IEnumerator SpawnLife()
    {
        yield return new WaitForSeconds(_lifespan);
        Destroy(gameObject);
    }
}
