using UnityEngine;
using System.Collections;
using Entitas;

public class PlayerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    Services _services;
    IGroup<GameEntity> _players;
    Vector2 updir = new Vector2(0,1);
    Vector2 leftdir = new Vector2(1,0);

    bool _coolOver = true;
    float _coolDown;
    float _maxCoolDown = 1;
    public PlayerUpdateSystem(Contexts contexts, Services services)
    {
        _players = contexts.game.GetGroup(GameMatcher.Player);
        _contexts = contexts;
        _services = services;
    }
    public void Execute()
    {
        if(_contexts.game.gameState.value != GameState.Run)
        {
            return;
        }


        var startpos = _contexts.config.planeConfig.startPos;
        foreach (var p in _players)
        {
            if(p.playerState.state == PlayerState.Appear)
            {
                //Debug.Log("Appear");
                if (p.position.value.y >= startpos.y)
                {
                    p.ReplacePlayerState(PlayerState.Run);
                }
                else
                {
                    var speed = _contexts.config.planeConfig.speed;
                    p.ReplacePosition(
                p.position.value + updir*speed*Time.deltaTime
                    );
                }
            }
            else if(p.playerState.state == PlayerState.Run)
            {
                //Debug.Log("Run");

                var speed = _contexts.config.planeConfig.speed;
                var keydata = _services.InputService.KeyData;
                var offset = Vector2.zero;
                if (keydata.isPressed(InputData.KeyState.Up))
                {
                    offset += Time.deltaTime * updir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Left))
                {
                    offset -= Time.deltaTime * leftdir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Down))
                {
                    offset -= Time.deltaTime * updir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Right))
                {
                    offset += Time.deltaTime * leftdir * speed;
                }

                var scenecollider = _contexts.config.sceneColider;

                var pos = p.position.value + offset;
                //if (pos.x > scenecollider.rd.x) ;
                pos.x = pos.x > scenecollider.rd.x ? scenecollider.rd.x : pos.x;
                pos.x = pos.x < scenecollider.lu.x ? scenecollider.lu.x : pos.x;
                pos.y = pos.y > scenecollider.lu.y ? scenecollider.lu.y : pos.y;
                pos.y = pos.y < scenecollider.rd.y ? scenecollider.rd.y : pos.y;

                p.ReplacePosition(
                pos
                    );

                _coolDown -= Time.deltaTime;
                if (_coolDown < 0)
                {
                    _coolOver = true;
                }

                var key = _services.InputService.KeyData;
                if(key.isPressed(InputData.KeyState.Enter) && _coolOver)
                {
                    var e = _contexts.game.CreateEntity();
                    e.AddBullet(true);
                    e.AddBulletState(BulletState.Run);
                    e.AddAsset("Bullet",1);
                    e.AddPosition(p.position.value);
                    e.AddMoveDirect(new Vector2(0,1));

                    _coolOver = false;
                    _coolDown = _maxCoolDown;
                }


            }
            if(p.hasView)
            {
                p.view.Value.Position = p.position.value;
            }

        }
    }
}
