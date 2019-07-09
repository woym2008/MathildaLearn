using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    static private EnemyManager _instance;
    static public EnemyManager getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EnemyManager();
            }
            return _instance;
        }
    }
    //-----------------------------------------------------------
    private List<EnemyController> _enemyList = new List<EnemyController>();
    //-----------------------------------------------------------
    private string _pathEnemy = "prefab/enemy";

    private GameObject _enemyPrefab;

    public bool _enable = false;

    public float CreateWaitTime = 1.0f;
    private float _curWaitTime = 0;

    //预计算好的一系列起始点
    public List<Vector2> _startpos = new List<Vector2>();

    //销毁飞机的点
    private Transform _destroyPoint;
    //-----------------------------------------------------------
    public void InitEnemyManager()
    {
        _enemyPrefab = Resources.Load(_pathEnemy) as GameObject;

        _enemyList.Clear();
        //--------------------------------
        var left = GameObject.Find("EnemyData/LeftStartPoint").transform.position;
        var right = GameObject.Find("EnemyData/RightStartPoint").transform.position;
        _destroyPoint = GameObject.Find("EnemyData/DestroyPoint").transform;

        //分成四个起始点
        var length = (right.x - left.x);
        var interval = (length / 4);
        for (int i=0;i<4;++i)
        {
            var pos = new Vector2(left.x + interval*i + interval * 0.5f, left.y);

            _startpos.Add(pos);
        }
    }

    public void StartEnemyManager()
    {
        _enable = true;
    }

    public void StopEnemyManager()
    {
        _enable = false;
    }

    private List<EnemyController> _destroyList = new List<EnemyController>();
    public void Update()
    {
        if(_enable)
        {
            //-------------------------------------------------
            foreach (var enemy in _enemyList)
            {
                enemy.UpdateMove();
                if(enemy.transform.position.y < _destroyPoint.position.y)
                {
                    _destroyList.Add(enemy);
                }
                else if(!enemy.IsAlive())
                {
                    _destroyList.Add(enemy);
                }
            }
            //-------------------------------------------------
            foreach (var destroyenemy in _destroyList)
            {
                _enemyList.Remove(destroyenemy);
                GameObject.Destroy(destroyenemy.gameObject);
            }
            _destroyList.Clear();
            //-------------------------------------------------
            _curWaitTime -= Time.deltaTime;
            if(_curWaitTime <= 0)
            {
                CreateEnemy();
                _curWaitTime = CreateWaitTime;
            }
        }
        
    }

    public void CreateEnemy()
    {
        var enemy = GameObject.Instantiate(_enemyPrefab).GetComponent<EnemyController>();
        var posindex = UnityEngine.Random.Range(0, _startpos.Count);
        enemy.transform.position = _startpos[posindex];
        _enemyList.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        _enemyList.Remove(enemy);

        GameObject.Destroy(enemy.gameObject);
    }
}
