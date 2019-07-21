using UnityEngine;
using System.Collections;

public class EnterController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameManager.Instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.Update(Time.deltaTime);
    }
}
