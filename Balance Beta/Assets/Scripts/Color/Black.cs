using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Black : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Black Cube")
                {
                    var.r = 0;
                    var.g = 0;
                    var.b = 0;
                    var.CorS = 0;
                    var.standartColor = false;
                    SceneManager.LoadScene("Menu");
                }

                if(hit.transform.name == "Black Sphere")
                {
                    var.r = 0;
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
