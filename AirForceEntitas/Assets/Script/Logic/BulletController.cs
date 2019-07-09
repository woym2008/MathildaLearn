using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    private GameEntity _entity;
    float lifetime = 5;

    public void InitCollide(GameEntity entity)
    {
        _entity = entity;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            _entity.ReplaceBulletState(BulletState.Die);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _entity.ReplaceBulletState(BulletState.Die);
        }
    }
}
