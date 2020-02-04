﻿/*
 * PlayerController.cs
 * By: Liam Binford
 * Date: 2/3/20
 * Description: Script for making the player character move
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //declare variables
    bool canMove = true;
    public Vector2 Destination = new Vector2();
    Rigidbody2D myRB;
    public float speed = 5;
    public bool isDead = false;
    public int lives = 5;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        Mathf.Round(transform.position.x);
        Mathf.Round(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is dead
        CheckForDeath();

        if(Input.GetAxis("Vertical") > 0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x, transform.position.y + 1);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
        }
        else if (Input.GetAxis("Vertical") < -0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x, transform.position.y - 1);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
        }
        else if (Input.GetAxis("Horizontal") > 0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x + 1, transform.position.y);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
        }
        else if (Input.GetAxis("Horizontal") < -0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x - 1, transform.position.y);
            StartCoroutine(Move());
            //make sure that the player moves into the center of each square
            Mathf.Round(transform.position.x);
            Mathf.Round(transform.position.y);
        }
    }

    IEnumerator Move()
    {
        while(Vector2.Distance(transform.position, Destination) > 0.001f)
        {
            myRB.MovePosition(Vector2.MoveTowards(transform.position, Destination, speed));
            yield return new WaitForFixedUpdate();
        }
        //wait until the key is released to allow further movement
        while(Input.GetAxis("Vertical") > 0.0107f || Input.GetAxis("Horizontal") > 0.0107f || Input.GetAxis("Vertical") < -0.0107f || Input.GetAxis("Horizontal") < -0.0107f)
        {
            yield return new WaitForFixedUpdate();
        }
        canMove = true;
    }

    //method run when the player is dead
    private void CheckForDeath()
    {
        if(isDead)
        {
            //the player loses a life, resets position, and is no longer dead
            lives--;
            transform.position = new Vector3(-0.15f, -3.5f, 0);
            isDead = false;
        }

        //TODO: Create game over condition

    }
}
