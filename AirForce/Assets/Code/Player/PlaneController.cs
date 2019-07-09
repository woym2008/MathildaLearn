using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneController : MonoBehaviour
{
    BulletEmitter _bulletEmitter;
    LifeController _lifeController;
    private void Awake()
    {
        _bulletEmitter = this.gameObject.GetComponent<BulletEmitter>();
        _lifeController = this.gameObject.GetComponent<LifeController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire()
    {
        _bulletEmitter.Fire();
    }

    public bool IsAlive()
    {
        if(_lifeController.Life <= 0)
        {
            return false;
        }

        return true;
    }
}
