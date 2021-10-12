/*
 * Created by: Andres Galiasso
 * Date Created: 09/22/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
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

    private void OnTriggerEnter(Collider collided)
    {

        Health h = collided.gameObject.GetComponent<Health>();
        
        if (h == null)
        {
            return;
        }
        h.SetHealth(h.GetHealth() - damage);
        Die();
         
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

}
