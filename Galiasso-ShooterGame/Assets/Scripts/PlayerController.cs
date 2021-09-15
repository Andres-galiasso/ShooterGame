/*
 * Created by: Andres Galiasso
 * Date Created: 09/13/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/15/2021
 * 
 * Description: Controls the player ship
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /**** VARIABLES ****/

    public bool mouseLook = true;
    public float maxSpeed = 5f;

    public string HAxis = "Horizontal";
    public string VAxis = "Vertical";
    public string fireAxis = "Fire1";

    private Rigidbody thisBody = null;


    private void Awake()
    {
        thisBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horz = Input.GetAxis(HAxis);
        float vert = Input.GetAxis(VAxis);

        Vector3 moveDirection = new Vector3(horz, 0f, vert);
        thisBody.AddForce(moveDirection.normalized * maxSpeed);

        thisBody.velocity = new Vector3(Mathf.Clamp(thisBody.velocity.x, -maxSpeed, maxSpeed),
            Mathf.Clamp(thisBody.velocity.y, -maxSpeed, maxSpeed),
            Mathf.Clamp(thisBody.velocity.z, -maxSpeed, maxSpeed));

        // Look at mouse
        if (mouseLook)
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0.0f));

            mousePosWorld = new Vector3(mousePosWorld.x, 0.0f, mousePosWorld.z);

            Vector3 lookDirection = mousePosWorld - transform.position;

            transform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
        }
    }


}
