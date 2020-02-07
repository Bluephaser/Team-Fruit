/* KillOnCollide.cs
 * By: Liam Binford 
 * Date: 2/3/20
 * Description: Kills the player if the object with this script collides with them
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollide : MonoBehaviour
{
    public AudioClip deathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player is the one touching collider
        if (collision.gameObject.GetComponent<PlayerController>() != null && collision.GetComponent<PlayerController>().touchingLog != true)
        {
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            collision.gameObject.GetComponent<PlayerController>().isDead = true;
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
