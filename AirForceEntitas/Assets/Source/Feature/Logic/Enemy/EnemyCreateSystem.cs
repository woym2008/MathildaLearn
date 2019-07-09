using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class EnemyCreateSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    public EnemyCreateSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        var posl = _contexts.config.enemyConfig.EnemyStartPoint_L;
        var posr = _contexts.config.enemyConfig.EnemyStartPoint_R;

        float posx = UnityEngine.Random.Range(posl.x, posr.x);
        var pos = new Vector2(posx,posl.y);

        foreach(var e in  entities)
        {
            e.AddAsset("Enemy", 3);
            e.AddPosition(pos);

            e.AddEnemyState(EnemyState.Alive);
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Enemy.Added());
    }
}
