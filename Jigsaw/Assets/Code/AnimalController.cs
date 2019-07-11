using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalController : MonoBehaviour
{
    public Transform CenterPoint;

    public int ColumeNumber = 3;

    public Vector2 Offset = new Vector2(1f,1f);
    // Use this for initialization
    void Start()
    {
        InitPickController();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RandomJigsaw();
        }
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

    public void RandomJigsaw()
    {
        if(_jigsaw != null && _jigsaw.Count > 0)
        {
            var count = _jigsaw.Count;
            var rownum = count / ColumeNumber;
            if (rownum * ColumeNumber > count)
            {
                rownum++;
            }

            var randomangle = Random.Range(0,360);
            var orimatrix = CenterPoint.worldToLocalMatrix;

            CenterPoint.rotation = CenterPoint.rotation * Quaternion.Euler(0, 0, randomangle);

            var targetmatrix = CenterPoint.localToWorldMatrix;

            for (int i=0;i<= rownum;++i)
            {
                for(int j=0;j<ColumeNumber;++j)
                {
                    var index = i * ColumeNumber + j;
                    if(index < _jigsaw.Count)
                    { 
                        var pos = CenterPoint.position + new Vector3(
                            Offset.x*i,
                            Offset.y*j,
                            _jigsaw[index].transform.position.z
                            );

                        var local = orimatrix * pos;

                        _jigsaw[index].transform.position = targetmatrix * local;
                    }
                }
            }
        }
    }
}
