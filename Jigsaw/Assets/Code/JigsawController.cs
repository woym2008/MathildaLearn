using UnityEngine;
using System.Collections;

public class JigsawController : MonoBehaviour
{
    public AnimalController ParentControllerœ;

    public Vector3 RightPosition;

    public Vector3 CurrentPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect()
    {
        this.transform.localScale = new Vector3(1.1f,1.1f,1f);
    }

    public void OnUnSelect()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
