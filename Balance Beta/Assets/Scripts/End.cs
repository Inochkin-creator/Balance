using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("play");

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
}
