using UnityEngine;
using System.Collections;

public class PickController : MonoBehaviour
{
    public enum InputState
    {
        NoPress,
        Press,
        Drag,
        Release,
    }
    public JigsawController _cacheJigsaw;

    public Camera _camera;

    public string JigsawTag = "Jigsaw";

    bool _IsMousePressed;

    public float AdsorbentDis = 1.0f;

    InputState _state;
    // Use this for initialization
    void Start()
    {
        _IsMousePressed = false;

        _state = InputState.NoPress;
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
                _state = InputState.Press;
            }
            if(_IsMousePressed && Input.GetMouseButtonUp(0))
            {
                //_cacheJigsaw = null;

                _IsMousePressed = false;

                _state = InputState.Release;
            }
            //拖拽
            if(_cacheJigsaw!= null && _IsMousePressed && Input.GetMouseButton(0))
            {
                _state = InputState.Drag;

            }

            switch(_state)
            {
                case InputState.NoPress:
                    break;
                case InputState.Press:
                    {
                        var ray = _camera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider != null && hit.collider.gameObject.CompareTag(JigsawTag))
                            {
                                var jcotrl = hit.collider.gameObject.GetComponent<JigsawController>();

                                if(jcotrl.CanPick())
                                {
                                    if (_cacheJigsaw != null)
                                    {
                                        _cacheJigsaw.OnUnSelect();
                                    }

                                    _cacheJigsaw = jcotrl;

                                    _cacheJigsaw.OnSelect(AdsorbentDis);
                                }

                            }
                        }
                    }
                    break;
                case InputState.Drag:
                    {
                        var ray = _camera.ScreenPointToRay(Input.mousePosition);

                        var pos = ray.direction * (_cacheJigsaw.transform.position.z - _camera.transform.position.z);
                        var newpos = new Vector3(_camera.transform.position.x + pos.x, _camera.transform.position.y + pos.y, _cacheJigsaw.transform.position.z);

                        _cacheJigsaw.transform.position = newpos;

                        _cacheJigsaw.OnDrag();
                    }


                    break;
                case InputState.Release:
                    {
                        if (_cacheJigsaw != null)
                        {
                            _cacheJigsaw.OnUnSelect();
                        }

                        _cacheJigsaw = null;
                    }
                    break;
            }
        }
    }
}
