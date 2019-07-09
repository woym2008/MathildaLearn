using UnityEngine;
using System.Collections;
using Entitas;

public class InputSystem : IExecuteSystem
{
    Services _services;
    public InputSystem(Contexts contexts, Services services)
    {
        _services = services;
    }

    public void Execute()
    {
        _services.InputService.Update(Time.deltaTime);
    }
}
