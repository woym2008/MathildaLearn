using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleProcess : IProcess
{
    ProcessFSM _fsm;
    private Button _startbtn;
    public TitleProcess(ProcessFSM fsm)
    {
        _fsm = fsm;
    }
    public void Enter()
    {
        var sbtn = GameObject.Find("StartBtn");
        _startbtn = sbtn.GetComponent<Button>();
        _startbtn.onClick.AddListener(OnClickStart);
    }

    public void Excute(float dt)
    {
        //throw new System.NotImplementedException();
    }

    public void Exit()
    {
        _startbtn.gameObject.SetActive(false);
    }

    private void OnClickStart()
    {
        _fsm.Process = new RunningProcess(_fsm);
    }
}
