using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class var
{
    public static int CorS = 0;
    public static int r, g, b;
    public static bool standartColor = true;
}

public class cubes_movement : MonoBehaviour
{
    Rigidbody Player;
    
    public GameObject Sphere;
    public GameObject Cube;

        Rigidbody Platform;
        public TextMeshPro Score;
        public TextMeshPro highScore;
        public GameObject EndText;
        public GameObject Plane;
    
    int force = 500, score = 0, t = 1, frames = 0;
    bool isGround = false, flag = false;

    void Start()
    {
        //Cursor.visible = false;
        Player = GetComponent<Rigidbody>(); 
        
        if (SceneManager.GetActiveScene().name == "play")
            Platform = Plane.GetComponent<Rigidbody>();

        if (var.CorS == 1)
        {
            Cube.SetActive(false);
            Sphere.SetActive(true);
        }

        if (!var.standartColor)
            Player.GetComponent<Renderer>().material.color = new Color(var.r, var.g, var.b);
    }

    void Update()
    {       

        if (score != 0)
            Score.text = "Score: " + score / 2;
        highScore.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (SceneManager.GetActiveScene().name == "play")
        {
            if (!flag)     
            {
                frames++;
                if (frames % 15 == 0)
                    score += t;
                if (frames % 150 == 0)
                {
                    t++;
                    if (Platform.mass > 25)
                    Platform.mass -= 0.5F;
                }
                if (frames % 300 == 0)
                {
                    t++;
                    if (Player.mass < 2)
                    Player.mass += 0.025F;
                }
            }
            
            if (score != 0)
                Score.text = "Score: " + score / 2;
            highScore.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                Player.AddForce(Vector3.up * force); 
                isGround = false;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                Player.AddForce(Vector3.forward * force / 50); 
            
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                Player.AddForce(Vector3.forward * -(force / 50));

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                Player.AddForce(Vector3.right * force / 50); 

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                Player.AddForce(Vector3.left * force / 50); 
        }
    }

    

    private void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "platform") isGround = true;

        if (col.gameObject.tag == "lose-platform") 
        {
            PlayerPrefs.SetInt("HighScore", Math.Max(score / 2, PlayerPrefs.GetInt("HighScore")));
            EndText.SetActive(true); flag = true; score = 0;
            //PlayerPrefs.DeleteAll();
        }
    } 
}
