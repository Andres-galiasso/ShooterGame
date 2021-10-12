/*
 * Created by: Andres Galiasso
 * Date Created: 10/11/2021
 * 
 * Last Edited by: Andres Galiasso
 * Last Updated: 10/11/2021
 * 
 * Description: Destroys on score lmao
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    /**** VARIABLES ****/

    public int scoreValue = 50;

    private void OnDestroy()
    {
        GameController.score += scoreValue;
    }

}
