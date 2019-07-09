using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Feature
{
    public GameSystem(Contexts contexts, Services services)
    {


        Add(new ResourceSystem(contexts, services));

        Add(new LogicSystem(contexts, services));

        Add(new GameEventSystems(contexts));

        Add(new InputSystem(contexts, services));
    }
}
