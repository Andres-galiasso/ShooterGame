/*
 * Created by: Andres Galiasso
 * Date Created: 09/27/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/27/2021
 * 
 * Description: Player health
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /**** VARIABLES ****/
    [SerializeField] private float healthPoints = 100f;
    public bool shouldDestroyOnDeath = true;

    public GameObject DeathParticlesPrefab = null;

    public float GetHealth()
    {
        return healthPoints;
    }

    public void SetHealth(float value)
    {
        healthPoints = value;
        if (healthPoints <= 0)
        {
            SendMessage("Die", SendMessageOptions.DontRequireReceiver);

            if (DeathParticlesPrefab != null)
            {
                Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
            }

            if (shouldDestroyOnDeath)
            {
                if (this.gameObject.tag == "Player")
                {
                    GameController.GameOver();
                }

                Destroy(gameObject);
            }
        }
    }


}
