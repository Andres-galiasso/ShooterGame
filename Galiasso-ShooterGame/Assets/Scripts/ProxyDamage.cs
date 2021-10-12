/*
 * Created by: Andres Galiasso
 * Date Created: 09/20/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/20/2021
 * 
 * Description: Brother momentum
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    /**** VARIABLES ****/
    public float damageRate = 10f; // Damage per second

    private void OnTriggerStay(Collider collided)
    {
        Health h = collided.gameObject.GetComponent<Health>();

        if (h = null)
        {
            return;
        }

        h.SetHealth(h.GetHealth() - (damageRate * Time.deltaTime));
        
    }
}
