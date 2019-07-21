using UnityEngine;
using System.Collections;

public class RunningProcess : IProcess
{
    ProcessFSM _fsm;
    MapController _map;
    public RunningProcess(ProcessFSM fsm)
    {
        _fsm = fsm;
    }
    public void Enter()
    {
        _map = GameObject.Find("Map").GetComponent<MapController>();

        _map.CreateMap();
    }

    public void Excute(float dt)
    {

    }

    public void Exit()
    {
        _map.DestroyMap();
    }
}
