/*
 * Door.cs
 * By: Alex Dzius
 * Last Edited: 1/28/2021
 * Manages Doors to be compatible with GameManager's out of bounds scene transferring
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "LastDoor" && GameManager.Divergence != 0)
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "BackDoor")
            {
                collision.gameObject.transform.position = new Vector3(transform.position.x - 5000, transform.position.y - 5000, transform.position.z);
            }
            else
            {
                collision.gameObject.transform.position = new Vector3(transform.position.x + 5000, transform.position.y + 5000, transform.position.z);
            }  
        }
    }
}
