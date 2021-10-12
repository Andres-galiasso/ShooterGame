/*
 * Created by: Andres Galiasso
 * Date Created: 09/20/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/20/2021
 * 
 * Description: Makes object face other object every frame
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObj : MonoBehaviour
{
    /**** VARIABLES ****/
    public Transform objToFace = null;
    public bool facePlayer = false;

    private void Start()
    {
        if (!facePlayer)
        {
            return;
        }
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");

        if (PlayerObj != null)
        {
            objToFace = PlayerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objToFace == null)
        {
            return;
        }

        Vector3 dirToObj = objToFace.position - transform.position;

        if (dirToObj != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(dirToObj.normalized, Vector3.up);
        }
    }
}
