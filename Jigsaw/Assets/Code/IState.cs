using UnityEngine;
using System.Collections;

public interface IState
{
    void Enter();
    void Excute(float dt);
    void Exit();
}

