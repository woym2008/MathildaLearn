using UnityEngine;
using System.Collections;

public interface IProcess
{
    void Enter();
    void Excute(float dt);
    void Exit();
}
