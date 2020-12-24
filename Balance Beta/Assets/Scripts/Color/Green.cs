using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Green Cube")
                {
                    var.r = 0;
                    var.g = 255;
                    var.b = 0;
                    var.CorS = 0;
                    var.standartColor = false;
                }

                if(hit.transform.name == "Green Sphere")
                {
                    var.r = 0;
                    var.g = 255;
                    var.b = 0;
                    var.CorS = 1;
                    var.standartColor = false;
                }
            }
        }
    }
}
