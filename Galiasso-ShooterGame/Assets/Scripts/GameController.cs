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
    public Text dynamicText = null;

    public float textTime = 5f;

    public int nextLevel = 250;
    public static bool level2 = false;

    private void Awake()
    {
        thisInstance = this;
    }

    private void Start()
    {
        dynamicText.text = "ENEMIES AHEAD! LIMITED MOVEMENT UNLOCKED! FIRE AT WILL!";
        thisInstance.dynamicText.gameObject.SetActive(true);
        Invoke("HideDynamicText", textTime);
    }

    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
        }

        if (score >= nextLevel)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        level2 = true;
        PlayerController.mouseLook = true;

        dynamicText.text = "ENEMIES FROM ALL SIDES! UNLOCKED FREE MOVEMENT!";
        thisInstance.dynamicText.gameObject.SetActive(true);
        Invoke("HideDynamicText", textTime);
    }

    public static void GameOver()
    {
        if (thisInstance.gameOverText != null)
        {
            thisInstance.gameOverText.gameObject.SetActive(true);
        }
    }

    private void HideDynamicText()
    {
        thisInstance.dynamicText.gameObject.SetActive(false);
    }

}
