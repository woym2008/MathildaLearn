using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameSystem _gamesystem;
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        var services = new Services(contexts);
        _gamesystem = new GameSystem(contexts, services);

        _gamesystem.Initialize();

        contexts.game.ReplaceGameState(GameState.Ready);
    }

    // Update is called once per frame
    void Update()
    {
        _gamesystem.Execute();
    }
}
