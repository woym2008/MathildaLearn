using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    FSM _fsm;

    private void Awake()
    {
        _fsm = new FSM();
        _fsm.State = new GameRunState(_fsm);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
