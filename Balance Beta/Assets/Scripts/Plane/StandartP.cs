using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandartP : MonoBehaviour
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
                if(hit.transform.name == "Standart")
                {
                    var.standartColor = true;
                    
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
        Player.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
 
    public void OnMouseExit()
    {    
        Player.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
