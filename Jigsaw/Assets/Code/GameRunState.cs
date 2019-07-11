using UnityEngine;
using System.Collections;

public class GameRunState : IState
{
    FSM _fsm;

    PickController _Controller;

    public GameRunState(FSM fsm)
    {
        _fsm = fsm;
    }

    public void Enter()
    {
        GameObject.Find("AnimalController");

        _Controller = GameObject.Find("Picker").GetComponent<PickController>();
    }

    public void Excute(float dt)
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
