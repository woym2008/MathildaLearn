using UnityEngine;
using System.Collections;

public class FSM
{
    private IState _state;

    public IState State
    {
        set
        {
            if(_state != null)
            {
                _state.Exit();
            }

            _state = value;

            _state.Enter();
        }
    }

}
