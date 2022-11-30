using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] powerups;

    private int spawnSide = 45;
    private float yTopBound = 24.0f;
    private float yBottomBound = 15.0f;
    private float powerUpBounds = 25.0f;

    void Start()
    {
        Invoke("SpawnEnemy", 2);
        Invoke("SpawnPowerUp", 5.0f);
    }

    private void SpawnPowerUp()
    {
        GameObject powerup = powerups[0];
        float xPos = Random.Range(-powerUpBounds, powerUpBounds);
        Vector3 spawnPos = new Vector3(xPos, 30.0f, 3);
        Instantiate(powerup, spawnPos, powerup.transform.rotation);

        float spawnTimer = Random.Range(5.0f, 30.0f);
        Invoke("SpawnPowerUp", spawnTimer);
    }

    private void SpawnEnemy()
    {
        int spawnSideLocal = spawnSide;
        int side = Random.Range(0, 2);

        int enemeyIndex = Random.Range(0, enemies.Length);
        GameObject enemy = enemies[enemeyIndex];
        Quaternion rotation;

        // spawns on right side
        if (side == 1)
        {
            rotation = Quaternion.Euler(0, 180, 0);
        }
        // spawns on left side
        else
        {
            spawnSideLocal = spawnSide * -1;
            rotation = enemy.transform.rotation;
        }
        

        float yPos = Random.Range(yTopBound, yBottomBound);

        Vector3 spawnPos = new Vector3(spawnSideLocal, yPos, 3);
        Instantiate(enemy, spawnPos, rotation);


        Invoke("SpawnEnemy", Random.Range(0.2f, 5.0f));
    }
}
