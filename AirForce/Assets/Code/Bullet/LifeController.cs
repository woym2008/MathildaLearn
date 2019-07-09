using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
    public int MaxLife = 1;
    private int _life = 1;
    public int Life
    {
        get
        {
            return _life;
        }
    }

    private void Awake()
    {
        _life = MaxLife;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit(int damage)
    {
        _life -= damage;
    }
}
