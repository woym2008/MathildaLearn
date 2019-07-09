using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum GameState
{
    Null,
    Ready,
    Title,
    Run,
    Over,
}

[Game]
[Unique]
public class GameStateComponent : IComponent
{
    public GameState value;
}
