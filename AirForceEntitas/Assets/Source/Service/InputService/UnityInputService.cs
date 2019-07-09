/* ========================================================
 *	类名称：UnityInputService
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:27:36
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InputData
{
    public enum KeyState
    {
        Left = 1,
        Right =2,
        Up = 4,
        Down = 8,
        Enter = 16
    }
    int presskey = 0;

    public void Clear()
    {
        //Debug.Log("presskey" + presskey);
        presskey = 0;
    }

    public void Press(KeyState k)
    {
        presskey |= (int)k;
        //Debug.Log("Press presskey" + presskey);
    }

    public bool isPressed(KeyState k)
    {
        if((presskey & (int)k) >0)
        {
            return true;
        }
        return false;
    }
}

public class UnityInputService : Service, IInputService
{

    InputData _data = new InputData();

    KeyCode _leftkey = KeyCode.A;
    KeyCode _rightkey = KeyCode.D;
    KeyCode _upkey = KeyCode.W;
    KeyCode _downkey = KeyCode.S;
    KeyCode _enterkey = KeyCode.Return;

    public UnityInputService(Contexts contexts)
        : base(contexts)
    {
    }


    public void Update(float delta)
    {

        _data.Clear();

        if(Input.GetKey(_leftkey))
        {
            _data.Press(InputData.KeyState.Left);
        }
        if (Input.GetKey(_rightkey))
        {
            _data.Press(InputData.KeyState.Right);
        }
        if (Input.GetKey(_upkey))
        {
            _data.Press(InputData.KeyState.Up);
        }
        if (Input.GetKey(_downkey))
        {
            _data.Press(InputData.KeyState.Down);
        }

        if (Input.GetKey(_enterkey))
        {
            _data.Press(InputData.KeyState.Enter);
        }
    }


    public InputData KeyData
    {
        get
        {
            return _data;
        }
    }
}
