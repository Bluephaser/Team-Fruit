using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string LevelLoad;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        if(LevelLoad == "quit")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(LevelLoad);
    }


}
