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
        if (pos.x <= 0f || pos.x >= 1f) 
        {
            speed *= sign;
        }
        myrb.velocity = new Vector2(speed,0);
    }
}
