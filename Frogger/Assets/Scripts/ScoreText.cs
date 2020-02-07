/* ScoreText.cs
 * By: Liam Binford
 * Date: 2/6/20
 * Description: Displays the player's current score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    //declare variables
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //start the score as 00000 and convert 0's to the score
        scoreText.text = "" + GameManager.score.ToString("00000");
    }
}
