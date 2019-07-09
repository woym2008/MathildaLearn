using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    public Transform _emitPoint;

    public float Colddown = 0.2f;
    private float _colddown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        _colddown -= Time.deltaTime;
        if (_colddown <= 0)
        {
            var b = BulletManager.getInstance.AddBullet();
            b.transform.position = _emitPoint.transform.position;
            var dir = (_emitPoint.transform.position - this.transform.position).normalized;
            b.Dir = dir;

            _colddown = Colddown;
        }
    }
}
