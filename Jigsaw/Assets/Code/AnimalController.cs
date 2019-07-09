using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    List<JigsawController> _jigsaw = new List<JigsawController>();

    public void InitPickController()
    {
        _jigsaw.Clear();

        //var childs = this.transform.GetComponentsInChildren<JigsawController>();
        for(int i=0;i< this.transform.childCount;++i)
        {
            var child = this.transform.GetChild(i);
            var c = child.gameObject.GetComponent<JigsawController>();
            if(c == null)
            {
                c = child.gameObject.AddComponent<JigsawController>();
            }
            _jigsaw.Add(c);
        }
    }

    public void FinishJigsaw(JigsawController jigsaw)
    {
        _jigsaw.Remove(jigsaw);
    }

}
