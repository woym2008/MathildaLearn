using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimalController : MonoBehaviour
{
    public Transform CenterPoint;

    public int ColumeNumber = 3;

    public Vector2 Offset = new Vector2(2f,2f);

    public Vector2 Bias = new Vector2(0.5f,0.5f);

    public Action OnFinishGame;
    // Use this for initialization
    void Start()
    {
        //InitPickController();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            InitPickController();
            RandomJigsaw();
        }
    }

    List<JigsawController> _jigsaw = new List<JigsawController>();

    public void InitPickController()
    {
        _jigsaw.Clear();

        List<JigsawController> templist = new List<JigsawController>();
        //var childs = this.transform.GetComponentsInChildren<JigsawController>();
        for (int i=0;i< this.transform.childCount;++i)
        {

            var child = this.transform.GetChild(i);
            if (child.gameObject.name == "base")
            {
                continue;
            }
            var c = child.gameObject.GetComponent<JigsawController>();
            if(c == null)
            {
                c = child.gameObject.AddComponent<JigsawController>();
            }
            //_jigsaw.Add(c);
            templist.Add(c);
        }


        foreach (var item in templist)
        {
            //_jigsaw.Remove(item);
            _jigsaw.Insert(UnityEngine.Random.Range(0, _jigsaw.Count + 1), item);
        }
        templist.Clear();
    }

    public void FinishJigsaw(JigsawController jigsaw)
    {
        _jigsaw.Remove(jigsaw);
        if(_jigsaw.Count == 0)
        {
            if(OnFinishGame != null)
            {
                OnFinishGame.Invoke();
            }
        }
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

            var randomangle = UnityEngine.Random.Range(0,360);
            var orimatrix = CenterPoint.worldToLocalMatrix;

            var centeroffset = Vector3.zero;
            centeroffset.x = Offset.x * rownum * 0.5f;
            centeroffset.y = Offset.y * ColumeNumber * 0.5f;

            CenterPoint.rotation = CenterPoint.rotation * Quaternion.Euler(0, 0, randomangle);

            var targetmatrix = CenterPoint.localToWorldMatrix;

            for (int i=0;i<= rownum;++i)
            {
                for(int j=0;j<ColumeNumber;++j)
                {
                    var index = i * ColumeNumber + j;
                    if(index < _jigsaw.Count)
                    {
                        var b = new Vector2(UnityEngine.Random.Range(-Bias.x, Bias.x), UnityEngine.Random.Range(-Bias.y, Bias.y));
                        var pos = CenterPoint.position + new Vector3(
                            Offset.x*i + b.x - centeroffset.x,
                            Offset.y*j + b.y - centeroffset.y,
                            _jigsaw[index].transform.position.z
                            );

                        var local = orimatrix * pos;

                        _jigsaw[index].transform.position = targetmatrix * local;

                        _jigsaw[index].ParentController = this;

                        _jigsaw[index].Ready();
                    }
                }
            }
        }
    }
}
