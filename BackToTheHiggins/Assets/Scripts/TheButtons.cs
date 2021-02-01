/*
 * TheButtons.cs
 * By: Alex Dzius
 * Last Edited: 1/26/21
 * desc: universal button scripts hangar, add proper button scripts to similar concept as shown below, used both for testing and implementation
 * Just add the right function to the OnClick event on the UI Button.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TheButtons : MonoBehaviour
{
    [SerializeField] private GameObject Instructions;
    public void AddDivergence()
    {
        GameManager.Divergence++;
    }
    public void SubDivergence()
    {
        GameManager.Divergence--;
    }
    public void ResetDivergence()
    {
        GameManager.Divergence = 0;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuLevel");
        GameManager.LevelNumber = 0; // needed for replayability
    }
    public void LoadInstructions()
    {
        // do setactive and unsetactive stuff for this, not a new level
        if ( Instructions.activeSelf == false)
        {
            Instructions.SetActive(true);
        } else
        {
            Instructions.SetActive(false);
        }
    }

}
