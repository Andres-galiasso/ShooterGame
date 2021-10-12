/*
 * Created by: Andres Galiasso
 * Date Created: 09/13/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
 * 
 * Description: Controls the player ship
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /**** VARIABLES ****/

    public static bool mouseLook = false;
    public float maxSpeed = 5f;
    public float reloadDelay = 0.3f;
    public bool canFire = true;
    public Transform[] turretTransforms;

    private string HAxis = "Horizontal";
    private string VAxis = "Vertical";
    private string fireAxis = "Fire1";

    private Rigidbody thisBody = null;


    private void Awake()
    {
        thisBody = this.gameObject.GetComponent<Rigidbody>();
        mouseLook = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown(fireAxis) && canFire)
        {
            foreach(Transform t in turretTransforms)
            {
                BulletManager.SpawnBullet(t.position, t.rotation);
            }
            canFire = false;
            Invoke("EnableFire", reloadDelay);
        }
    }

    private void FixedUpdate()
    {
        float horz = Input.GetAxis(HAxis);
        float vert = Input.GetAxis(VAxis);

        /*
         * annoying floaty movement dont use lmao
         * (keep just in case your movement is somehow worse)
         * 
        Vector3 moveDirection = new Vector3(horz, 0f, vert);
        thisBody.AddForce(moveDirection.normalized * maxSpeed);

        thisBody.velocity = new Vector3(Mathf.Clamp(thisBody.velocity.x, -maxSpeed, maxSpeed),
            Mathf.Clamp(thisBody.velocity.y, -maxSpeed, maxSpeed),
            Mathf.Clamp(thisBody.velocity.z, -maxSpeed, maxSpeed));
        */

        Vector3 movement = new Vector3(horz * maxSpeed, 0f, vert * maxSpeed);
        transform.Translate(movement * Time.deltaTime);

        // Look at mouse
        if (mouseLook)
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0.0f));

            mousePosWorld = new Vector3(mousePosWorld.x, 0.0f, mousePosWorld.z);

            Vector3 lookDirection = mousePosWorld - transform.position;

            transform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
    }

    private void EnableFire()
    {
        canFire = true;
    }

}
