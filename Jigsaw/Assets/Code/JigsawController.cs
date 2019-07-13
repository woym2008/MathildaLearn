using UnityEngine;
using System.Collections;

public class JigsawController : MonoBehaviour
{
    public enum State
    {
        Ready,
        PickNoShine,
        PickShine,
        Putdown
    }
    public AnimalController ParentController;

    public Vector3 RightPosition;

    public Vector3 CurrentPosition;

    State _state;

    float _absorbDis;

    Material _Mat;

    private void Awake()
    {
        RightPosition = this.transform.position;
        _state = State.Putdown;

        var jigsawrenderer = this.gameObject.GetComponent<Renderer>();
        if(jigsawrenderer != null)
        {
            _Mat = jigsawrenderer.material;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentPosition = this.transform.position;
    }

    public void Ready()
    {
        _state = State.Ready;
    }

    public void SetRightPosition(Vector3 pos)
    {
        RightPosition = pos;
    }

    public void OnSelect(float abdis)
    {
        this.transform.localScale = new Vector3(1.1f,1.1f,1f);

        _state = State.PickNoShine;

        _absorbDis = abdis;
    }

    public void OnUnSelect()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);


        if (IsPick(_absorbDis))
        {
            PutJigsaw();
        }
    }

    bool IsPick(float dis = 0f)
    {
        if(Vector3.Distance(CurrentPosition,RightPosition) <= dis)
        {
            return true;
        }

        return false;
    }

    void PutJigsaw()
    {
        _state = State.Putdown;

        this.transform.position = RightPosition;

        //Debug.LogError("Putdown Jigsaw");

        if (_Mat != null)
        {
            _Mat.color = new Color(1f, 1, 1, 1);
        }

        ParentController.FinishJigsaw(this);
    }

    public void OnDrag()
    {
        if(_state == State.PickNoShine)
        {
            if(IsPick(_absorbDis))
            {
                _state = State.PickShine;

                if(_Mat != null)
                {
                    _Mat.color = new Color(0.5f, 1, 1, 1);
                }
            }
        }
        else if(_state == State.PickShine)
        {
            if(!IsPick(_absorbDis))
            {
                _state = State.PickNoShine;
                if (_Mat != null)
                {
                    _Mat.color = new Color(1f, 1, 1, 1);
                }
            }
        }
    }

    public bool CanPick()
    {
        if(_state == State.Putdown)
        {
            return false;
        }
        return true;
    }
}
