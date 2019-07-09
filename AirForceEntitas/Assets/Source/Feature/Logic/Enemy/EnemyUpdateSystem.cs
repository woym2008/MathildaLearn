using UnityEngine;
using System.Collections;
using Entitas;

public class EnemyUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    IGroup<GameEntity> _Enemys;

    float coldtime = 1;
    float _colddowm = 0;

    Vector2 downdir = new Vector2(0, -1);
    public EnemyUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;

        _Enemys = contexts.game.GetGroup(GameMatcher.Enemy);
    }
    public void Execute()
    {
        if(_contexts.game.gameState.value != GameState.Run)
        {
            return;
        }
        var speed = _contexts.config.enemyConfig.sppedmax;
        foreach(var e in _Enemys)
        {
            var offset = e.position.value + speed * downdir * Time.deltaTime;

            e.ReplacePosition(offset);

            if(e.hasView)
            {
                e.view.Value.Position = e.position.value;
            }

            if(e.enemyState.state == EnemyState.Die)
            {
                e.isDestroyed = true;
            }
        }

        _colddowm -= Time.deltaTime;
        if (_colddowm <= 0)
        {
            _colddowm = coldtime;
            var enemy = _contexts.game.CreateEntity();
            enemy.ReplaceEnemy(true);
        }
    }
}
