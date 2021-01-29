using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool IsPressed = false;
    private bool IsReleased = false;
    private bool IsHeld = false;

    public SpriteRenderer sr;

    public Sprite On;
    public Sprite Off;

    private int toggleInt = 0;

    public bool Signal; //The value other objects read
    public enum ButtonTypeEnum
    {
        Once, //The button cannot be turned off once it is pressed
        Hold, //The button is released when the player steps off
        Toggle //The button is released the next time the player touches it
    }

    public ButtonTypeEnum ButtonType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonType == ButtonTypeEnum.Once)
        {
            if (IsPressed == true)
                SignalOn();
        }

        else if (ButtonType == ButtonTypeEnum.Hold)
        {
            if (IsHeld == true)
                SignalOn();

            else if (IsHeld == false)
                SignalOff();
        }

        else if (ButtonType == ButtonTypeEnum.Toggle)
        {
            if (IsPressed == true)
            {
                if (toggleInt % 2 != 0)
                    SignalOn();

                else if (toggleInt % 2 == 0)
                    SignalOff();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPressed) return;
        IsPressed = true;
        toggleInt++;
        IsReleased = false;
        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsReleased = true;
        IsHeld = false;
        Debug.Log("Exit");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsHeld = true;
        IsPressed = false;
    }

    private void SignalOn()
    {
        Signal = true;
        sr.sprite = On;
    }

    private void SignalOff()
    {
        Signal = false;
        sr.sprite = Off;
    }

}
