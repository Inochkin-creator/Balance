using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
{
    Rigidbody arrow;
    
    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<Rigidbody>();
        arrow.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SceneManager.LoadScene("Skins Plane");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SceneManager.LoadScene("Skins");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Arrow")
                    if (SceneManager.GetActiveScene().name == "Skins")
                        SceneManager.LoadScene("Skins Plane");
                    else if (SceneManager.GetActiveScene().name == "Skins Plane")
                        SceneManager.LoadScene("Skins");


            }
        }
    }

    public void OnMouseOver()
    {  
        arrow.GetComponent<Renderer>().material.color = new Color32(120, 120, 170, 255);
    }
 
    public void OnMouseExit()
    {    
        arrow.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
    }
}
