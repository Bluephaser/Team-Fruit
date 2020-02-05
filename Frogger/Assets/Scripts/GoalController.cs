using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public bool activated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player touched and hasn't touched beforme
        if(collision.gameObject.GetComponent<PlayerController>() != null
            && activated == false)
        {
            activated = true;

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
