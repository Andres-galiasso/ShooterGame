/*
 * Created by: Andres Galiasso
 * Date Created: 09/22/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
 * 
 * Description: Spawns enemies around player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /**** VARIABLES ****/
    public float maxRadius = 1f;
    public float interval = 5f;
    public GameObject[] objToSpawn;
    private Transform origin = null;

    private void Awake()
    {
        origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, interval);
    }

    private void Spawn()
    {
        if (origin == null)
        {
            return;
        }

        Vector3 spawnPos = origin.position + Random.onUnitSphere * maxRadius;
        spawnPos = new Vector3(spawnPos.x, 0f, spawnPos.z);
        SpawnRandomEnemy(spawnPos);
    }

    private void SpawnRandomEnemy(Vector3 spawnPos)
    {
        int rand = Random.Range(0, 2);

        if (!GameController.level2)
        {
            rand = 1;
        }

        switch(rand)
        {
            case 0:
                SpawnChaser(rand, spawnPos);
                break;
            case 1:
                SpawnShooter(rand);
                break;
        }

    }

    private void SpawnChaser(int enemyType, Vector3 spawnPos)
    {
        Instantiate(objToSpawn[enemyType], spawnPos, Quaternion.identity);
    }

    private void SpawnShooter(int enemyType)
    {
        int randDir;
        if (GameController.level2)
        {
            randDir = Random.Range(0, 2);
        }
        else
        {
            randDir = 0;
        }

        int randPos = Random.Range(-5, 6);
        float oneDirection = 3f;
        switch (randDir)
        {
            case 0:
                oneDirection = 3f;
                break;
            case 1:
                oneDirection = -3f;
                break;
        }

        Vector3 spnPos = new Vector3(randPos, 0f, oneDirection);

        Instantiate(objToSpawn[enemyType], spnPos, Quaternion.identity);
    }

}
