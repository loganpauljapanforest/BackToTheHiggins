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
    //If you wish to modify divergence, just add to GameManager.Divergence the amount you need.
    public static int Divergence = 0;
    public static int LevelNumber = 0; // index for levelNames, allows for traversing levels, 
    //but will not work if you start in like level 2 with index 0, thatll set you back a level if 
    //you try and go forward

    // this is the text GAMEOBJECT that holds the 2 texts, known as TextHolder in the hierarchy
    // as its an array of text, either [0] or [1] is the actual divergence counter, not the title
    // so you can fix that
    [SerializeField] private Text[] divergenceText;
    // this is the player, just ensure the player prefab has a lower case spelling of prefab
    [SerializeField] private GameObject player;
    // this is the build settings order of all levels, you need to have an exact copy of them in the right order to have them work.
    private string[] levelNames = {"Level1", "Level1.5", "Level2", "Level3", "WinScreen" };
    private GameObject textholder;
    // Start is called before the first frame update
    void Start()
    {
        // gamemanager duplication check, we only need 1
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
        // this is to find the player gameobject in each level
        player = GameObject.Find("player");
        // this finds the texts in the scene, where either [0] or [1] is the DIVERGENCE title, and the other is the counter
        if (LevelNumber < levelNames.Length - 1)
        {
            textholder = GameObject.Find("TextHolder");
            divergenceText = textholder.GetComponentsInChildren<Text>();
            divergenceText[1].text = Divergence.ToString();
        }
        // color change
        if (Divergence == 0)
        {
            divergenceText[1].color = Color.green;
        }
        else
        {
            divergenceText[1].color = Color.red;
        }
        // as discussed, this is the rewind, resets level and resets divergence
        if (Input.GetKey("r"))
        {
            Divergence = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // screen edges, its basically checking on which side of the screen you went through
        // <0 = going left, >1 going right
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
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
            if (LevelNumber <= levelNames.Length)
            {
                SceneManager.LoadScene(levelNames[LevelNumber]);
            } 
        }

        //this is something for the build, doesnt work in editor
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
