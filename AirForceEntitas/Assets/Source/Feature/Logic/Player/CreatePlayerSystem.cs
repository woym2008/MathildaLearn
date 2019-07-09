using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreatePlayerSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Services _services;

    public CreatePlayerSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
        _services = services;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        var planedata = _contexts.config.planeConfig;
        var bornpos = planedata.bornPos;

        var plane = _contexts.game.CreateEntity();
        plane.AddPlayerState(PlayerState.Appear);
        plane.isPlayer = true;
        plane.ReplacePosition(bornpos);
        plane.AddAsset("Plane",4);

        _contexts.game.ReplacePlayerBorn(false);
        _contexts.game.ReplacePlayerData((_contexts.game.playerData.life--));
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.playerBorn.isBorning == true);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlayerBorn);
    }
}
