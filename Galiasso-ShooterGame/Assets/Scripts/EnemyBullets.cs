/*
 * Created by: Andres Galiasso
 * Date Created: 10/06/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
 * 
 * Description: Fires bullets at intervals for enemy-fire
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    /**** Variables ****/

    public float reloadDelay = 1f;
    private bool canFire = true;
    public Transform[] turretTransforms;

    private void FixedUpdate()
    {
        if (canFire)
        {
            foreach (Transform t in turretTransforms)
            {
                

                BulletManager.SpawnBullet(t.position, t.rotation);
            }
            canFire = false;
            Invoke("EnableFire", reloadDelay);
        }
    }

    private void EnableFire()
    {
        canFire = true;
    }


}
