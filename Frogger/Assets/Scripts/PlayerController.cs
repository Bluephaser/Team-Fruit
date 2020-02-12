/*
 * PlayerController.cs
 * By: Liam Binford
 * Date: 2/3/20
 * Description: Script for making the player character move
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //declare variables
    public bool canMove = true;
    public Vector2 Destination = new Vector2();
    Rigidbody2D myRB;
    public float speed = 5;
    public bool isDead = false;
    public bool touchingLog = false;
    Vector3 highestYPos;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        Mathf.Round(transform.position.x);
        Mathf.Round(transform.position.y);
        highestYPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x, transform.position.y + 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x, transform.position.y - 1);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x + 1, transform.position.y);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x - 1, transform.position.y);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        //check if the player is dead
        CheckForDeath();

        //check for increase in height
        IsGoingUp();
    }

    IEnumerator Move()
    {
        GetComponent<Animator>().SetInteger("State", 1);
        GetComponent<AudioSource>().PlayOneShot(jumpSound);
        while(Vector2.Distance(transform.position, Destination) > 0.001f)
        {
            myRB.MovePosition(Vector2.MoveTowards(transform.position, Destination, speed));
            yield return new WaitForFixedUpdate();
        }
        //wait until the key is released to allow further movement
        while(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            yield return new WaitForFixedUpdate();
        }
        canMove = true;
        GetComponent<Animator>().SetInteger("State", 0);
    }

    //method run when the player is dead
    private void CheckForDeath()
    {
        if(isDead)
        {
            //the player loses a life, resets position, and is no longer dead
            GameManager.lives--;
            transform.position = new Vector3(-0.15f, -3.5f, 0);
            StopAllCoroutines();
            isDead = false;
            canMove = true;
            GetComponent<Animator>().SetInteger("State", 0);
        }

        //TODO: Create game over condition
        if(GameManager.lives == -1)
        {
            SceneManager.LoadScene("Main Menu 1");
        }
    }

    //method for detecting increase in upwards movement
    private void IsGoingUp()
    {
        if(transform.position.y > highestYPos.y)
        {
            GameManager.score += 10;
            highestYPos.y++;
        }
    }
}
