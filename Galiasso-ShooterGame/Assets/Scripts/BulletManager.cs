/*
 * Created by: Andres Galiasso
 * Date Created: 09/22/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/22/2021
 * 
 * Description: Read the fucking name dipshit
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    /**** VARIABLES ****/
    
    public static BulletManager bulletManagerSingleton = null;

    public GameObject bulletPrefab = null;
    public int poolSize = 100;
    public Queue<Transform> bulletQueue = new Queue<Transform>();

    private GameObject[] bulletArray;

    #region BulletManagerSet
    private void SetBulletManager()
    {
        if (bulletManagerSingleton == null)
        {
            bulletManagerSingleton = this;
        }
        else
        {
            bulletManagerSingleton = null;
        }
    }
    #endregion BulletManagerSet

    private void Awake()
    {
        SetBulletManager();

        if (bulletManagerSingleton == null) { return; }

        bulletArray = new GameObject[poolSize];
        
        for (int i = 0; i < poolSize; i++)
        {
            bulletArray[i] = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform objTransform = bulletArray[i].transform;

            bulletQueue.Enqueue(objTransform);
            bulletArray[i].SetActive(false);
        }
    }

    public static Transform SpawnBullet(Vector3 position_in, Quaternion rotation_in)
    {
        Transform spawnedBullet = bulletManagerSingleton.bulletQueue.Dequeue();

        spawnedBullet.gameObject.SetActive(true);
        spawnedBullet.position = position_in;
        spawnedBullet.localRotation = rotation_in;

        bulletManagerSingleton.bulletQueue.Enqueue(spawnedBullet);

        return spawnedBullet; ;
    }

}
