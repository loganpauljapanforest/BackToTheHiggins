/*
 * PlayerController.cs
 * By: Liam Binford
 * Last Edited: 1/28/2021
 * Player Movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myrb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float maxSpeed;
    bool grounded = true;
    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Movement();
        Jumping();
        if(myrb.velocity.x > maxSpeed)
        {
            myrb.velocity = new Vector2(maxSpeed, myrb.velocity.y);
        }
        if(myrb.velocity.x < -maxSpeed)
        {
            myrb.velocity = new Vector2(-maxSpeed, myrb.velocity.y);
        }
    }

    void Movement()
    {
        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            myrb.AddForce(new Vector2(speed, 0));
        }
        else if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            myrb.AddForce(new Vector2(-speed, 0));
        }
        else if (myrb.velocity.x > 0)
        {
            myrb.velocity = new Vector2(myrb.velocity.x - 0.1f, myrb.velocity.y);
        }
        else if (myrb.velocity.x < 0)
        {
            myrb.velocity = new Vector2(myrb.velocity.x + 0.1f, myrb.velocity.y);
        }
    }

    void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            myrb.AddForce(new Vector2(0, jumpForce));
            print(jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            grounded = true;
        }
    }
}
