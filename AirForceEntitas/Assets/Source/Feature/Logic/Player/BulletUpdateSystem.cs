using UnityEngine;
using System.Collections;
using Entitas;

public class BulletUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    IGroup<GameEntity> _bullets;
    public BulletUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;

        _bullets = contexts.game.GetGroup(GameMatcher.Bullet);
    }
    public void Execute()
    {
        if(_contexts.game.gameState.value != GameState.Run)
        {
            return;
        }

        var speed = _contexts.config.planeConfig.bulletspeed;
        foreach (var bullet in _bullets)
        {
            var newpos = bullet.position.value + bullet.moveDirect.dir * speed * Time.deltaTime;
            bullet.ReplacePosition(newpos);
            if(bullet.hasView)
                bullet.view.Value.Position = newpos;

            if (bullet.bulletState.state == BulletState.Die)
            {
                bullet.isDestroyed = true;
            }
        }
    }
}
