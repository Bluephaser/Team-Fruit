using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public int dir;
    public float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var tranpos = transform.position;
        GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(tranpos, tranpos + new Vector3(dir, 0, 0), speed));
    }
}
