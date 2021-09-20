/*
 * Created by: Andres Galiasso
 * Date Created: 09/20/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/20/2021
 * 
 * Description: Moves object in direction facing at constant speed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /**** VARIABLES ****/

    public float maxSpeed = 2f;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * maxSpeed * Time.deltaTime;
    }
}
