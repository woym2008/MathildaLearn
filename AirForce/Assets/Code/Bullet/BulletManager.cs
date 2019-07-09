using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager
{
    static private BulletManager _instance;
    static public BulletManager getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BulletManager();
            }
            return _instance;
        }
    }
    //--------------------------------------------
    string path = "prefab/bullet";
    //--------------------------------------------
    private List<BulletController> _bulletList = new List<BulletController>();

    private GameObject _prefab;
    //--------------------------------------------
    public void InitBulletManager()
    {
        _prefab = Resources.Load(path) as GameObject;
    }
    public BulletController AddBullet()
    {
        var b = GameObject.Instantiate(_prefab).GetComponent<BulletController>();

        _bulletList.Add(b);

        return b;
    }

    public void RemoveBullet(BulletController b)
    {
        _bulletList.Remove(b);

        GameObject.Destroy(b.gameObject);
    }
    //--------------------------------------------
    
    //--------------------------------------------
}
