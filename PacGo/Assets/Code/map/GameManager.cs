using UnityEngine;
using System.Collections;

public class GameManager
{
    ProcessFSM _process;

    static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void StartGame()
    {
        _process = new ProcessFSM();
        _process.Process = new TitleProcess(_process);
    }

    public void Update(float dt)
    {
        if(_process != null)
        {
            _process.Update(dt);
        }
    }
}
