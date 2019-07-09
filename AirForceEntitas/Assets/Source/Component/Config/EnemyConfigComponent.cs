using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class EnemyConfigComponent : IComponent
{
    public Vector2 EnemyStartPoint_L;
    public Vector2 EnemyStartPoint_R;

    public float sppedmax;
    public float speedmin;
}
