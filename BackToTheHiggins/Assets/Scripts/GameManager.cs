/*
 * GameManager.cs
 * By: Alex Dzius
 * Last Edited: 1/26/2021
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
    public static int LevelNumber = 5; // Build Settings Number for the First Level
    [SerializeField] private Text divergenceText;
    [SerializeField] private GameObject player;
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
        // divergence update
        divergenceText.text = Divergence.ToString();
        // rewind
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
        }
        // get screen edges
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
        
        /* TODO: MAKE A BOUNDS CHECK FOR LAST LEVEL, TO NOT EXCEED IT */
        // if hits left side screen go left a level
        if ( pos.x < 0.0 )
        {
            LevelNumber--;
            if (LevelNumber >= 5)
            {
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(LevelNumber).ToString());
            } 
        } 
        // if hits right side 
        else if ( pos.x > 1.0)
        {
            LevelNumber++;
            // do load stuff of next scene
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(LevelNumber).ToString());
        }

        // escape ability
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
