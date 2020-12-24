using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 255);
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
                    var.r = 0;
                    var.g = 0;
                    var.b = 255;
                    var.CorS = 0;
                    var.standartColor = false;
                }

                if(hit.transform.name == "Blue Sphere")
                {
                    var.r = 0;
                    var.g = 0;
                    var.b = 255;
                    var.CorS = 1;
                    var.standartColor = false;
                }
            }
        }
    }
}
