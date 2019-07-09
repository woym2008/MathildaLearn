using UnityEngine;
using System.Collections;

public class PickController : MonoBehaviour
{
    public JigsawController _cacheJigsaw;

    public Camera _camera;

    bool _IsMousePressed;
    // Use this for initialization
    void Start()
    {
        _IsMousePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePresent)
        {
            //点击
            if(Input.GetMouseButtonDown(0))
            {
                //ray

                _IsMousePressed = true;
            }
            if(_IsMousePressed && Input.GetMouseButtonUp(0))
            {
                _cacheJigsaw = null;

                _IsMousePressed = false;
            }

            //拖拽
            if(_cacheJigsaw!= null && _IsMousePressed && Input.GetMouseButton(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

            }
        }
    }
}
