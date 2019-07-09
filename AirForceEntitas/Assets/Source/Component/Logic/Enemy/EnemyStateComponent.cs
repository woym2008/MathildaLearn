using UnityEngine;
using System.Collections;
using Entitas;

public enum EnemyState
{
    Alive,
    Die
}
[Game]
public class EnemyStateComponent : IComponent
{
    public EnemyState state;
}
