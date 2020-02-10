/* FlyController.cs
 * By: Liam Binford
 * Date: 2/10/20
 * Description: Kill fly on collide, give 200 points. move randomly from goal to goal.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    //declare variables
    int goalNum;
    float timer;
    float timer2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player touches the fly, destroy it and give the player 200 points
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.score += 200;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goalNum = Random.Range(1, 5);
        timer += Time.deltaTime;
        if (timer >= 3 && gameObject.GetComponent<Renderer>().enabled == false)
        {
            switch (goalNum)
            {
                case 1:
                    transform.position = new Vector3(-5.934f, 9, 0);
                    break;
                case 2:
                    transform.position = new Vector3(-2.934f, 9, 0);
                    break;
                case 3:
                    transform.position = new Vector3(0.069f, 9, 0);
                    break;
                case 4:
                    transform.position = new Vector3(3.07f, 9, 0);
                    break;
                case 5:
                    transform.position = new Vector3(6.07f, 9, 0);
                    break;
            }
            timer = 0;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        if(timer >= 3 && gameObject.GetComponent<Renderer>().enabled == true)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            timer = 0;
            transform.position = new Vector3(100, 100, 0);
        }
    }

    IEnumerator wait()
    {
        while(timer < 3)
        {
            yield return new WaitForFixedUpdate();
        }
        timer = 0;
    }

}
