using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Red : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Red Cube")
                {
                    var.r = 255;
                    var.g = 0;
                    var.b = 0;
                    var.CorS = 0;
                    var.standartColor = false;
                    SceneManager.LoadScene("Menu");
                }

                if(hit.transform.name == "Red Sphere")
                {
                    var.r = 255;
                    var.g = 0;
                    var.b = 0;
                    var.CorS = 1;
                    var.standartColor = false;
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
