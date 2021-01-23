using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 255);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Green")
                {
                    var.rp = 0;
                    var.gp = 255;
                    var.bp = 0;
                    
                    var.standartColorp = false;
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
