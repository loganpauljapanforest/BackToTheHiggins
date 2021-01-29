/*
 * DoorController.cs
 * By: CJ S
 * Last Edited: 1/29/2021
 * Controls doors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Input;
    public bool IsOpen = false;

    private BoxCollider2D bc;

    public SpriteRenderer sr;

    public Sprite Open;
    public Sprite Closed;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpen == false &&
            Input.GetComponent<ButtonController>().Signal == true)
            OpenDoor();

        else if (IsOpen == true &&
            Input.GetComponent<ButtonController>().Signal == false)
            CloseDoor();
    }

    private void OpenDoor()
    {
        IsOpen = true;
        bc.enabled = false;
        sr.sprite = Open;
    }

    private void CloseDoor()
    {
        IsOpen = false;
        bc.enabled = true;
        sr.sprite = Closed;
    }
}
