/*
 * EnemyCollison.cs
 * By: Alex Dzius
 * Last Edited: 1/27/2021
 * Script to reload scene upon death (colliding with an 'enemy object'
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
