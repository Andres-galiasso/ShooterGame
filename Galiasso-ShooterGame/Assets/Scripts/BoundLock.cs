/*
 * Created by: Andres Galiasso
 * Date Created: 09/15/2021
 *
 * Last Edited by: Andres Galiasso
 * Last Updated: 09/15/2021
 * 
 * Description: Bounds of the level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundLock : MonoBehaviour
{
    /**** VARIABLES ****/

    public Rect levelBounds;

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, levelBounds.xMin, levelBounds.xMax),
            transform.position.y, Mathf.Clamp(transform.position.z, levelBounds.yMin, levelBounds.yMax));
    }

    private void OnDrawGizmosSelected()
    {
        const int CUBEDEPTH = 1;

        Vector3 boundsCenter = new Vector3(levelBounds.xMin + levelBounds.width * 0.5f, 0f, levelBounds.yMin + levelBounds.height * 0.5f);
        Vector3 boundsHeight = new Vector3(levelBounds.width, CUBEDEPTH, levelBounds.height);

        Gizmos.DrawWireCube(boundsCenter, boundsHeight);
    }
}
