using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int Power = 1;
    //子弹速度
    public float Speed = 8;
    //子弹发射方向
    public Vector3 Dir = new Vector3(0,1,0);
    //子弹使用计时方式做控制
    public float Lifetime = 1.5f;
    float _lifetime = 0;

    public string EnemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        _lifetime = Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Speed * Dir * Time.deltaTime ;
        if(_lifetime < 0)
        {
            BulletManager.getInstance.RemoveBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == EnemyTag)
        {
            LifeController l = collision.gameObject.GetComponent<LifeController>();
            l.OnHit(Power);
            _lifetime = -1;
        }
    }
}
