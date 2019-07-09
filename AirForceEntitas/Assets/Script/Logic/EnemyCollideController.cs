using UnityEngine;
using System.Collections;

public class EnemyCollideController : MonoBehaviour
{
    private GameEntity _entity;

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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyDie")
        {
            _entity.ReplaceEnemyState(EnemyState.Die);
        }
    }
}
