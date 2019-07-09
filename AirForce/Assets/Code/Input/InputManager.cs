using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectKey
{
    Null,
    Up,
    Down,
    Left,
    Right
}

public delegate void DirectKeyPress(DirectKey dir);
public delegate void ConfirmKeyPress();

public class InputManager
{
    static private InputManager _instance;
    static public InputManager getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InputManager();
            }
            return _instance;
        }
    }
    //--------------------------------------------------------
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;

    public KeyCode ConfirmKey = KeyCode.K;
    //定义一些按键事件
    public event DirectKeyPress onDirectKeyPress;
    public event ConfirmKeyPress onConfirmKeyPress;

    public void InitInputManager()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        var dir = DirectKey.Null;
        if(Input.GetKey(LeftKey))
        {
            dir = DirectKey.Left;
        }
        else if(Input.GetKey(RightKey))
        {
            dir = DirectKey.Right;
        }
        else if (Input.GetKey(UpKey))
        {
            dir = DirectKey.Up;
        }
        else if (Input.GetKey(DownKey))
        {
            dir = DirectKey.Down;
        }
        if(dir != DirectKey.Null)
        {
            onDirectKeyPress(dir);
        }

        if(Input.GetKey(ConfirmKey))
        {
            if(onConfirmKeyPress != null)
            {
                onConfirmKeyPress();
            }
        }
    }
}
