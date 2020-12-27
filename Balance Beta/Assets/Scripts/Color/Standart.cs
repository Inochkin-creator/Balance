using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Standart : MonoBehaviour
{
    public GameObject Player;

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
                    SceneManager.LoadScene("Menu");
                }

                if(hit.transform.name == "Standart Sphere")
                {
                    var.standartColor = true;
                    var.CorS = 1;
                    SceneManager.LoadScene("Menu");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
            SceneManager.LoadScene("Menu");
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("scene1");
    }

    public void OnMouseOver()
    {  
        Player.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }
 
    public void OnMouseExit()
    {    
        Player.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
    }
}
