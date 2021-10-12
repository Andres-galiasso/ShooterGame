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
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /**** VARIABLES ****/

    public static GameController thisInstance = null;

    public static int score;
    public string scorePrefix = string.Empty;
    public Text scoreText = null;
    public Text gameOverText = null;

    private void Awake()
    {
        thisInstance = this;
    }

    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
        }
    }

    public static void GameOver()
    {
        if (thisInstance.gameOverText != null)
        {
            thisInstance.gameOverText.gameObject.SetActive(true);
        }
    }

}
