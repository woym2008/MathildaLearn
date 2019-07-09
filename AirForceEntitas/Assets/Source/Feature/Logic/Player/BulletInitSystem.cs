using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class BulletInitSystem : ReactiveSystem<GameEntity>
{
    public BulletInitSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var ec = e.view.Value.Transform.gameObject.GetComponent<BulletController>();
            ec.InitCollide(e);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.hasBullet && entity.isAssetLoaded == true);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AssetLoaded);
    }
}
