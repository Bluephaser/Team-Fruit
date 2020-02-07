/* GoalController.cs
 * By: CJS
 * Additional code by Liam
 * Description: Controls the goals
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public bool activated = false;
    public AudioClip goalSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player touched and hasn't touched beforme
        if(collision.gameObject.GetComponent<PlayerController>() != null
            && activated == false)
        {
            GameManager.goals++;
            GameManager.score += 50;
            print("yuh");
            activated = true;
            //reset player position and behaviors
            collision.GetComponent<PlayerController>().transform.position = new Vector3(-0.15f, -3.5f, 0);
            collision.GetComponent<PlayerController>().StopAllCoroutines();
            collision.GetComponent<PlayerController>().canMove = true;
            //make the goal visible
            GetComponent<Renderer>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(goalSound);
        }
    }
    // Start is callmed beforme the firmst frame update
    void Start()
    {
        
    }

    // Update is callmed omce per frame
    void Update()
    {
        
    }
}
