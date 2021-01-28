/*
 * EnemyMovement.cs
 * By: Alex Dzius
 * Last Edited: 1/28/2021
 * Enemy Movement to stay within bounds of the map and respond to red colored moveable walls and goomba-dying
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myrb;
    private float speed = 2f;
    private int sign = -1;
    // Start is called before the first frame update
    void Start()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(myrb.transform.position);
        if (pos.x <= 0.1f || pos.x >= 0.9f) 
        {
            speed *= sign;
        }
        myrb.velocity = new Vector2(speed,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > gameObject.transform.position.y + 0.5)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            speed *= sign;
        }
    }
}
