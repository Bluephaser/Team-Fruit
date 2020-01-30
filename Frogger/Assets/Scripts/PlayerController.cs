/*
 * PlayerController.cs
 * By: Liam Binford
 * Date: 1/30/20
 * Description: Script for making the player character move
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canMove = true;
    Vector2 Destination = new Vector2();
    Rigidbody2D myRB;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(0, transform.position.y + 1);

            StartCoroutine(Move());
        }
        if (Input.GetAxis("Vertical") < -0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(0, transform.position.y -1);

            StartCoroutine(Move());
        }
        if (Input.GetAxis("Horizontal") > 0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x + 1, 0);

            StartCoroutine(Move());
        }
        if (Input.GetAxis("Horizontal") < -0.01f && canMove)
        {
            //disable movement until the player has moved an entire square
            canMove = false;
            Destination = new Vector2(transform.position.x - 1, 0);

            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        while(Vector2.Distance(transform.position, Destination) > 0.001f)
        {
            myRB.MovePosition(Vector2.MoveTowards(transform.position, Destination, speed));
            yield return new WaitForFixedUpdate();
        }
        canMove = true;
    }
}
