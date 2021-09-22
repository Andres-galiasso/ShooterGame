/*
 * Created by: Andres Galiasso
 * Date Created: 09/22/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/22/2021
 * 
 * Description: Does whatever a bullet does
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    /**** VARIABLES ****/
    public float damage = 100f;
    public float lifeTime = 2f;

    // 
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
         * Health h = other.gameObject.getComponent<Health>();
         * 
         * h.healthPoint -= damage;
         * Die();
         */
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

}
