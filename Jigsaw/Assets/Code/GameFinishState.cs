using UnityEngine;
using System.Collections;

public class GameFinishState : IState
{
    FSM _fsm;
    public GameFinishState(FSM fsm)
    {
        _fsm = fsm;
    }

    public void Enter()
    {
        Debug.LogError("Finish Game");
    }

    public void Excute(float dt)
    {
    }

    public void Exit()
    {
    }
}
