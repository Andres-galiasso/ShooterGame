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

        Instantiate(objToSpawn[rand], spawnPos, Quaternion.identity);
    }

}
