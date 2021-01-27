/*
 * DivergenceAdjustment.cs
 * By: Alex Dzius
 * Last Edited: 1/27/2021
 * Script to adjust divergence upon collision with specific objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivergenceAdjustment : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Positive")
            {
                GameManager.Divergence--;
            }
            else if (gameObject.tag == "Negative")
            {
                GameManager.Divergence++;
            }
            else;
        }
    }
}
