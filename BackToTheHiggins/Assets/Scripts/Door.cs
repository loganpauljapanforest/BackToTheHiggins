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
            else
            {
                collision.gameObject.transform.position = new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z);
            }  
        }
    }
}
