using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myrb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            myrb.AddForce(new Vector2(speed, 0));
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            myrb.AddForce(new Vector2(-speed, 0));
        }

        Jumping();
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
