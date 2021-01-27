using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class Menu : MonoBehaviour
{
    public TextMeshPro text;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Screen.fullScreen = !Screen.fullScreen;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("scene1");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Return")
                    SceneManager.LoadScene("scene1");

                if (hit.transform.name == "skin")
                    SceneManager.LoadScene("Skins");
                    
                if (hit.transform.name == "statistics")
                    SceneManager.LoadScene("Statistics");
                    
                if (hit.transform.name == "Quit")
                    Application.Quit();

            }
        }
    }

    public void OnMouseOver()
    {  
        text.color = new Color32(120, 120, 170, 255);
    }
 
    public void OnMouseExit()
    {    
       text.color = new Color(255, 255, 255);
    }
}
