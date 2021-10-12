/*
 * Created by: Andres Galiasso
 * Date Created: 10/07/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
 * 
 * Description: Moves the enemy-fire
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMove : MonoBehaviour
{
    /**** VARIABLES ****/

    public float maxSpeed = 6f;
    public float acceleration = 0.2f;
    public float currentSpeed = 0f;
    private float movePositive = 1f;

    private Rigidbody thisBody = null;

    private void Awake()
    {
        thisBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Start() // this might just be stupid but i might combine awake() and start() later (if u wanna)
    {
        if (gameObject.transform.position.z <= 0)
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Update()
    {
        if ((movePositive == 1 && currentSpeed >= maxSpeed) || (movePositive == -1 && currentSpeed <= maxSpeed * -1))
        {
            movePositive *= -1;
        }

        currentSpeed += maxSpeed * movePositive * Time.deltaTime;
        thisBody.velocity = new Vector3(currentSpeed, 0f, 0f);
    }


}
