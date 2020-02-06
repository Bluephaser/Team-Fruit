using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public int dir;
    public float speed;
    public float trigger;
    public Vector3 dest;
    // Start is called before the first frame update


    //just use ontriggerenter for triggers
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            var tranpos = collision.gameObject.GetComponent<Transform>().position;
            collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(tranpos, tranpos + new Vector3(dir, 0, 0), speed));
            collision.gameObject.GetComponent<PlayerController>().touchingLog = true;
        }
        else
        {
           // collision.gameObject.GetComponent<PlayerController>().touchingLog = false;
        }
    }

    void Start()
    {
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 tranpos = transform.position;
        //this equals that, but NOT VICE VERSA
        //KEEP THAT IN MIND, DUMB DUMB

        GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(tranpos, tranpos + new Vector3(dir, 0, 0), speed));

        //if direction is left
        if (dir == -1)
        {
            //if position is far enough
            if (tranpos.x <= trigger)
            {
                transform.position = dest;
            }
        }

        if (dir == 1)
        {
            if (tranpos.x >= trigger)
            {
                transform.position = dest;
            }
        }
    }
}

