using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(1, 2, 3);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Blue Cube")
                {
                    var.r = 1;
                    var.g = 2;
                    var.b = 3;
                    var.CorS = 0;
                    var.standartColor = false;
                    SceneManager.LoadScene("Menu");
                }

                if(hit.transform.name == "Blue Sphere")
                {
                    var.r = 1;
                    var.g = 2;
                    var.b = 3;
                    var.CorS = 1;
                    var.standartColor = false;
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
