using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class var
{
    public static int CorS = 0;
    public static int r, g, b;
    public static bool standartColor = true;
    public static int rp, gp, bp;
    public static bool standartColorp = true;
    public static bool logo = false;
}

public class cubes_movement : MonoBehaviour
{
    Rigidbody Player;
    
    public GameObject Sphere;
    public GameObject Cube;

        Rigidbody Platform;
        Rigidbody PlatformLogo;
        public TextMeshPro Score;
        public TextMeshPro highScore;
        public GameObject EndText;
        public GameObject Plane;
        public GameObject PlaneLogo;
    
    int force = 500, score = 0, t = 1, frames = 0;
    bool isGround = false, flag = false;

    void Start()
    {
        //Cursor.visible = false;
        Player = GetComponent<Rigidbody>();  
        Platform = Plane.GetComponent<Rigidbody>();
        PlatformLogo = PlaneLogo.GetComponent<Rigidbody>();

        if (SceneManager.GetActiveScene().name == "play")
        {
            float x = Random.Range(-2.5f, 2.5f);
            float z = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(x, 5, z);
            Player.position = position;
        }
            
        if (SceneManager.GetActiveScene().name == "play")
        {
            if (var.CorS == 0)
                PlayerPrefs.SetFloat("CubeGamesPlayed", PlayerPrefs.GetFloat("CubeGamesPlayed", 0) + 1);
            if (var.CorS == 1)
                PlayerPrefs.SetFloat("SphereGamesPlayed", PlayerPrefs.GetFloat("SphereGamesPlayed", 0) + 0.5f);
            PlayerPrefs.SetFloat("TotalGamesPlayed", 
                PlayerPrefs.GetFloat("CubeGamesPlayed", 0) + PlayerPrefs.GetFloat("SphereGamesPlayed", 0));
        }
        
        if (!var.standartColor)
            Player.GetComponent<Renderer>().material.color = new Color(var.r, var.g, var.b);
        if (!var.standartColorp)
            Platform.GetComponent<Renderer>().material.color = new Color(var.rp, var.gp, var.bp);
        if (var.logo)
        {
            PlaneLogo.SetActive(true);
            Plane.SetActive(false);
        }


        if (var.CorS == 1)
        {
            Cube.SetActive(false);
            Sphere.SetActive(true);
        }
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.F))
            Screen.fullScreen = !Screen.fullScreen;
            
        if (SceneManager.GetActiveScene().name == "play")
        {
            if (score != 0)
                Score.text = "Score: " + score / 2;
            if (var.CorS == 0)
            {
                PlayerPrefs.SetInt("CubeHighScore", Math.Max(score / 2, PlayerPrefs.GetInt("CubeHighScore")));
                highScore.text = "High score: " + PlayerPrefs.GetInt("CubeHighScore", 0).ToString();
            }
            if (var.CorS == 1)
            {
                PlayerPrefs.SetInt("SphereHighScore", Math.Max(score / 2, PlayerPrefs.GetInt("SphereHighScore")));
                highScore.text = "High score: " + PlayerPrefs.GetInt("SphereHighScore", 0).ToString();
            }
            PlayerPrefs.SetInt("TotalHighScore", 
                Math.Max(PlayerPrefs.GetInt("SphereHighScore"), PlayerPrefs.GetInt("CubeHighScore")));

            if (!flag)     
            {
                frames++;
                if (frames % 15 == 0)
                    score += t;
                if (frames % 150 == 0)
                {
                    if (Platform.mass > 25)
                        Platform.mass -= 0.5F;
                    if (PlatformLogo.mass > 25)
                        PlatformLogo.mass -= 0.5F;
                }
                if (frames % 300 == 0)
                {
                    t++;
                    if (Player.mass < 2)
                        Player.mass += 0.025F;
                }
                if (frames % 1800 == 0)
                {
                    t++;
                    if (Player.mass < 2.5)
                        Player.mass += 0.025F;
                    if (Platform.mass > 10)
                        Platform.mass -= 0.25F;
                }
            }

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
            EndText.SetActive(true); flag = true; 
        }
    } 
}
