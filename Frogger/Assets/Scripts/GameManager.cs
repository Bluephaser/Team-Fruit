﻿/* GameManager.cs
 * By: Liam Binford
 * Date: 2/4/20
 * Description: This script weaves together many elements and scripts of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //declare variables
    public static int score = 0;
    public static int goals = 0;
    public static int lives = 5;
    public string LoadedLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //beat the level upon 5 goals cleared
        if (goals == 5)
        {
            LevelClear();
        }
        //lose if the player runs out of lives
        if(lives == -1)
        {
            print("game over, dude");
        }
    }

    void LevelClear()
    {
        print("level clear");
        SceneManager.LoadScene(LoadedLevel);
    }
}
