using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class PlaneConfigComponent : IComponent
{
    public int planeBornTime;

    public Vector2 bornPos;

    public Vector2 startPos;

    public float speed;

    public float bulletspeed;

}
