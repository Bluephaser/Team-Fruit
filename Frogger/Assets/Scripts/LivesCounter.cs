/* LivesCounter.cs
 * By: Liam Binford
 * Date: 2/5/20
 * Description: Destroys objects depending on how many lives the player has
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public int LifeValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.lives < LifeValue)
        {
            Destroy(gameObject);
        }
    }
}
