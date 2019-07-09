using UnityEngine;
using System.Collections;
using Entitas;

[Game]
public class BulletComponent : IComponent
{
    public bool isBullet;
}

public enum BulletState
{
    Run,
    Die
}
[Game]
public class BulletStateComponent : IComponent
{
    public BulletState state;
}