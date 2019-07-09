using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = -2.0f;

    private LifeController _lifeCtrl;

    private void Awake()
    {
        _lifeCtrl = this.gameObject.GetComponent<LifeController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMove()
    {
        this.transform.position = this.transform.position + new Vector3(0,Speed*Time.deltaTime,0);
    }

    public bool IsAlive()
    {
        if(_lifeCtrl.Life <= 0)
        {
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifeController l = collision.gameObject.GetComponent<LifeController>();
            l.OnHit(999);
        }
    }
}
