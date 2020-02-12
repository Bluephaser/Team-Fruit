/* GameManager.cs
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
    public AudioClip otherSide1;
    public AudioClip otherSide2;
    public AudioClip otherSide3;
    public AudioClip otherSide4;
    public AudioClip otherSide5;
    public AudioClip levelMusic;

    int lastPlayed = 0;

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

        switch(goals)
        {
            case 0:
                break;
            case 1:
                if (GetComponent<AudioSource>().clip != otherSide1 && lastPlayed < goals)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = otherSide1;
                    GetComponent<AudioSource>().Play();
                    lastPlayed++;
                    // GetComponent<AudioSource>().clip = levelMusic;
                }
                break;
            case 2:
                if (GetComponent<AudioSource>().clip != otherSide2 && lastPlayed < goals)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = otherSide2;
                    GetComponent<AudioSource>().Play();
                    lastPlayed++;
                    // GetComponent<AudioSource>().clip = levelMusic;
                }
                break;
            case 3:
                if (GetComponent<AudioSource>().clip != otherSide3 && lastPlayed < goals)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = otherSide3;
                    GetComponent<AudioSource>().Play();
                    lastPlayed++;
                    // GetComponent<AudioSource>().clip = levelMusic;
                }
                break;
            case 4:
                if (GetComponent<AudioSource>().clip != otherSide4 && lastPlayed < goals)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = otherSide4;
                    GetComponent<AudioSource>().Play();
                    lastPlayed++;
                    // GetComponent<AudioSource>().clip = levelMusic;
                }
                break;
            case 5:
                if (GetComponent<AudioSource>().clip != otherSide5 && lastPlayed < goals)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = otherSide5;
                    GetComponent<AudioSource>().Play();
                    lastPlayed++;
                    //  GetComponent<AudioSource>().clip = levelMusic;
                }
                break;
        }

        if(GetComponent<AudioSource>().clip != levelMusic && GetComponent<AudioSource>().isPlaying == false)
        {
            
            GetComponent<AudioSource>().clip = levelMusic;
            GetComponent<AudioSource>().Play();
        }

    }

    void LevelClear()
    {
        print("level clear");
        SceneManager.LoadScene(LoadedLevel);
    }
}
