using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedP : MonoBehaviour
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
                if(hit.transform.name == "Red")
                {
                    var.rp = 255;
                    var.gp = 0;
                    var.bp = 0;
                    
                    var.standartColorp = false;
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
