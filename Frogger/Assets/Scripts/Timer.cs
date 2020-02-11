/* Timer.cs
 * By: Liam Binford
 * Description: Counts down the time and shrinks the bar  with every second
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time;
    float increment;
    public int timeTotal;
    public int primaryTime;
    public bool isSecond;
    GameObject firstBar;


    // Start is called before the first frame update
    void Start()
    {
        increment = transform.localScale.x / timeTotal;
        firstBar = GameObject.Find("TimeBar");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5 && !isSecond && transform.localScale.x > 0.00001f)
        {
            transform.localScale = new Vector3(transform.localScale.x - increment, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x + increment / 2, transform.position.y, transform.position.z);
            time = 0;
        }
        else if (time >= 1 && isSecond && firstBar.transform.localScale.x <= 0.000001f)
        {
            transform.localScale = new Vector3(transform.localScale.x - increment, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x + increment / 2, transform.position.y, transform.position.z);
            time = 0;
        }
    }
}
