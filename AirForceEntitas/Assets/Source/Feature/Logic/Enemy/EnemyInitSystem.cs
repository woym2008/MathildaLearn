using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class EnemyInitSystem : ReactiveSystem<GameEntity>
{
    public EnemyInitSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var ec = e.view.Value.Transform.gameObject.GetComponent<EnemyCollideController>();
            ec.InitCollide(e);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.hasEnemy && entity.isAssetLoaded == true);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AssetLoaded);
    }
}
