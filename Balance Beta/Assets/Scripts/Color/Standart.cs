using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Standart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Standart Cube")
                {
                    var.standartColor = true;
                    var.CorS = 0;
                }

                if(hit.transform.name == "Standart Sphere")
                {
                    var.standartColor = true;
                    var.CorS = 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("scene1");
    }
}
