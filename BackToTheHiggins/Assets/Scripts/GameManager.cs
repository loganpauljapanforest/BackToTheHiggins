/*
 * GameManager.cs
 * By: Alex Dzius
 * Last Edited: 1/28/2021
 * The all-knowing script.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    /*
     * If you wish to modify divergence, just add to GameManager.Divergence the amount you need.
     */
    public static int Divergence = 0;
    public static int LevelNumber = 2; // index for current level
    [SerializeField] private Text[] divergenceText;
    [SerializeField] private GameObject player;
    private string[] levelNames = { "MainLevel", "Level1", "Level2", "Level3", "WinScreen" };
    // Start is called before the first frame update
    void Start()
    {
        GameManager[] anObject = FindObjectsOfType<GameManager>();
        if(anObject.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // border updare
        Vector3 ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        GameObject SideObstacleLeft = GameObject.Find("LeftBorder");
        GameObject SideObstacleRight = GameObject.Find("RightBorder");
        GameObject SideObstacleTop = GameObject.Find("TopBorder");
        GameObject SideObstacleBottom = GameObject.Find("DownBorder");
        GameObject TextHolder = GameObject.Find("TextHolder");
        SideObstacleLeft.transform.position = new Vector3(-ScreenSize.x, 0, 0);
        SideObstacleRight.transform.position = new Vector3(ScreenSize.x, 0, 0);
        SideObstacleTop.transform.position = new Vector3(0, ScreenSize.y, 0);
        SideObstacleBottom.transform.position = new Vector3(0, -ScreenSize.y, 0);
        TextHolder.transform.position = new Vector3(0, ScreenSize.y - ScreenSize.y * 0.55f, 0);
        // player update
        player = GameObject.Find("player");
        // divergence update
        divergenceText = FindObjectsOfType<Text>();
        divergenceText[1].text = Divergence.ToString();
        if (Divergence == 0)
        {
            divergenceText[1].color = Color.green;
        }
        else
        {
            divergenceText[1].color = Color.red;
        }
        // rewind
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // get screen edges
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
        /* TODO: ADJUST ABOVE NAME ARRAY FOR IMPLEMENTATION OF LEVELS */
        // if hits left side screen go left a level
        if ( pos.x < 0.0 )
        {
            LevelNumber--;
            if (LevelNumber >= 0)
            {
                SceneManager.LoadScene(levelNames[LevelNumber]);
            } 
        } 
        // if hits right side 
        else if ( pos.x > 1.0)
        {
            LevelNumber++;
            // do load stuff of next scene'
            if ( LevelNumber <= levelNames.Length)
            {
                SceneManager.LoadScene(levelNames[LevelNumber]);
            }
        }

        // escape ability
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
