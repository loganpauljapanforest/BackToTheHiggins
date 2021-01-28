using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool IsPressed = false;
    private bool IsReleased = false;
    private bool IsHeld = false;

    public bool Signal; //The value other objects read
    enum ButtonTypeEnum
    {
        Once, //The button cannot be turned off once it is pressed
        Hold, //The button is released when the player steps off
        Toggle //The button is released the next time the player touches it
    }

    ButtonTypeEnum ButtonType;

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
                Signal = true;
        }

        else if (ButtonType == ButtonTypeEnum.Hold)
        {
            if (IsHeld == true)
                Signal = true;

            else if (IsHeld == false)
                Signal = false;
        }

        else if (ButtonType == ButtonTypeEnum.Toggle)
        {
            if (IsPressed == true)
            {
                if (Signal == false)
                    Signal = true;

                else if (Signal == true)
                    Signal = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsPressed = true;
        IsReleased = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsPressed = false;
        IsReleased = true;
        IsHeld = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        IsHeld = true;
    }

}
