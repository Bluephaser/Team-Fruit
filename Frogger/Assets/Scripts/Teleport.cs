using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 dest;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.GetComponent<CarController>() != null)
            //if CarController exists within collided object
        {
            gameObject.GetComponent<CarController>().transform.position = dest;
                //this is asking for gameObjects that have CarController
                //therefore this refers to the whole gameObject, not the car controller
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
