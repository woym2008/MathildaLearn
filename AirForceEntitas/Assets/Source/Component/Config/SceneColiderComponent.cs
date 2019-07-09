using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class SceneColiderComponent : IComponent
{
    public Vector2 lu;
    public Vector2 rd;
}
