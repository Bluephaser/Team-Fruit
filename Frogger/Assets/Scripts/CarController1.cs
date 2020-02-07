/* CarController.cs
 * By: CJS
 * Description: Controls the cars
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public int dir;
    public float speed;
    public float trigger;
    public Vector3 dest;

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
