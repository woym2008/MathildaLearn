using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public class PlayerData : IComponent
{
    public int life;

}

[Game]
public class PlayerComponent : IComponent
{

}

[Game]
[Unique]
public class PlayerBornComponent : IComponent
{
    public bool isBorning;
}

public enum PlayerState
{
    Appear,
    Run,
    Die,
}

[Game]
public class PlayerStateComponent : IComponent
{
    public PlayerState state;
}
