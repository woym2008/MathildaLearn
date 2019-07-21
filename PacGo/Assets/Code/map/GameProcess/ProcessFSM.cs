using UnityEngine;
using System.Collections;

public class ProcessFSM
{
    private IProcess _process;

    public IProcess Process
    {
        set
        {
            if(_process != null)
            {
                _process.Exit();
            }
            _process = value;

            _process.Enter();
        }

        get
        {
            return _process;
        }
    }

    public void Update(float dt)
    {
        _process.Excute(dt);
    }

}
