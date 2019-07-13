using UnityEngine;
using System.Collections;

public class GameRunState : IState
{
    FSM _fsm;

    PickController _PickController;

    AnimalController _AnimController;

    public GameRunState(FSM fsm)
    {
        _fsm = fsm;
    }

    public void Enter()
    {
        //_AnimController = GameObject.Find("Animal").GetComponent<AnimalController>();
        _AnimController = GameObject.FindWithTag("Animal").GetComponent<AnimalController>();

        _PickController = GameObject.Find("Picker").GetComponent<PickController>();

        _AnimController.OnFinishGame = OnFinish;
    }

    public void Excute(float dt)
    {
    }

    public void Exit()
    {
    }

    void OnFinish()
    {
        _fsm.State = new GameFinishState(_fsm);
    }
}
