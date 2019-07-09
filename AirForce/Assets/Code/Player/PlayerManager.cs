using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//这个枚举 用来控制玩家当前状态
public enum PlayerState
{
    Null,   //还没开始游戏
    Appear, //刚刚登场，还不能操作
    Playing,//正在玩
    Die     //死了
}
public class PlayerManager
{
    static private PlayerManager _instance;
    static public PlayerManager getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }
            return _instance;
        }
    }

    private PlayerState _state = PlayerState.Null;

    private PlaneController _plane;

    //飞机预制体
    private string _planePath = "prefab/plane";
    private GameObject _planePrefab;
    //-------------------------------------------------
    //飞机需要从场景外出生 然后飞到场景中。之后交给玩家控制
    //飞机出生的位置
    private Transform _bornPoint;
    //飞机抵达战场的位置
    private Transform _startPoint;
    //飞机抵达战场时间
    const float AppearTime = 1.0f;
    //当前抵达战场已经花费的时间
    private float _curAppearTime;
    //-------------------------------------------------
    //飞机当前还有的生命
    private int _planeLife = 3;
    //-------------------------------------------------
    //玩家速度与当前帧速度
    private const float PlayerSpeed = 5.0f;
    private Vector2 _curSpeed = Vector2.zero;
    //-------------------------------------------------
    //游戏开始 初始化玩家
    public void InitPlayerManager()
    {
        //加载预制体
        _planePrefab = Resources.Load(_planePath) as GameObject;
        //寻找场景中的主角飞机起始点
        _bornPoint = GameObject.Find("PlaneData/BornPoint").transform;
        //寻找场景中的主角飞机抵达点
        _startPoint = GameObject.Find("PlaneData/StartPoint").transform;
        //飞机开始游戏后有三条命
        _planeLife = 3;
        //飞机出场计时初始化为0
        _curAppearTime = 0;

        InputManager.getInstance.onDirectKeyPress += new DirectKeyPress(OnInputDirectKey);

        InputManager.getInstance.onConfirmKeyPress += new ConfirmKeyPress(OnInputFire);
    }

    public void Update()
    {
        //最简单的状态机 switch
        switch(_state)
        {
            case PlayerState.Null:
                {
                    ;
                }
                break;
            case PlayerState.Appear:
                {
                    _curAppearTime += Time.deltaTime;
                    if(_curAppearTime >= AppearTime)
                    {
                        _curAppearTime = AppearTime;
                        _state = PlayerState.Playing;
                    }
                    var pos = Vector3.Lerp(_bornPoint.position, _startPoint.position, _curAppearTime/ AppearTime);
                    _plane.transform.position = pos;
                }
                break;
            case PlayerState.Playing:
                {
                    if(_plane != null)
                    {
                        _plane.transform.position = new Vector2(_plane.transform.position.x, _plane.transform.position.y) + _curSpeed * Time.deltaTime;
                    }
                    _curSpeed = Vector2.zero;
                }
                break;
            case PlayerState.Die:
                {
                    ;
                }
                break;
        }

        if(_plane != null)
        {
            if(!_plane.IsAlive())
            {
                PlaneDestory();
            }
        }
    }

    //启动玩家
    public void StartPlayer()
    {
        PlaneGo();
    }
    //飞机出发
    private void PlaneGo()
    {
        //创建一个飞机实体 然后切换状态到飞机开始向场景中飞
        var plane = GameObject.Instantiate(_planePrefab) as GameObject;
        _plane = plane.GetComponent<PlaneController>();
        _plane.transform.position = _bornPoint.position;
        _state = PlayerState.Appear;
    }

    //飞机击毁
    private void PlaneDestory()
    {
        GameObject.Destroy(_plane.gameObject);

        _plane = null;

        _state = PlayerState.Die;

        //飞机销毁后 生命减少，如果没命了，游戏结束
        //如果还有命，再生成一个
        _planeLife--;
        if(_planeLife == 0)
        {
            GameManager.getInstance.GameOver();
        }
        else
        {
            PlaneGo();
        }
    }

    //玩家响应输入系统的函数
    private void OnInputDirectKey(DirectKey dir)
    {
        //如果是正在玩的状态，就可以响应输入了
        if(_state == PlayerState.Playing)
        {
            switch(dir)
            {
                case DirectKey.Down:
                    {
                        _curSpeed = new Vector2(0, -PlayerSpeed);
                    }
                    break;
                case DirectKey.Up:
                    {
                        _curSpeed = new Vector2(0, PlayerSpeed);
                    }
                    break;
                case DirectKey.Left:
                    {
                        _curSpeed = new Vector2(-PlayerSpeed, 0);
                    }
                    break;
                case DirectKey.Right:
                    {
                        _curSpeed = new Vector2(PlayerSpeed, 0);
                    }
                    break;
            }
        }
    }

    private void OnInputFire()
    {
        if(_plane != null)
        {
            _plane.Fire();
        }
    }
}
