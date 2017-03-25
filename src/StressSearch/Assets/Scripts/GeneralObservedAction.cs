using UnityEngine;
using System.Collections;
using System;

public class GeneralObservedAction : MonoBehaviour, IObservedAction
{
    public bool IsObservable
    {
        get { return _FreezeTime <= 0; }
    }

    public bool HasAction
    {
        get
        {
            return _hasAction;
        }
    }
    protected bool _hasAction = false;

    public bool HasAnimation
    {
        get { return _hasAnimation; }
    }
    protected bool _hasAnimation = true;

    public int AnimationOption = 1;

    protected float _FreezeTime = 0;
    protected string _animationOption = "ShakeZ";


    public void BeingObserved() 
    {
        if (HasAnimation) 
            this.GetComponent<Animator>().SetBool(_animationOption, true);
    }

    public void Idle()
    {
    }

    public void StopedBeingObserved()
    {
        if (HasAnimation)
            this.GetComponent<Animator>().SetBool(_animationOption, false);
        Idle();
    }

    public void SetFreezeTime(float seconds)
    {
        _FreezeTime = seconds;
        if ((int)_FreezeTime < 0)
            _FreezeTime = 0;
    }

    public void subtractFreezeTime( float seconds)
    {
        _FreezeTime -= seconds;
        if ((int)_FreezeTime < 0)
            _FreezeTime = 0;
    }

    void Start()
    {
        switch (AnimationOption)
        {
            case 1:
                _animationOption = "ShakeZ";
                break;
            case 2:
                _animationOption = "ShakeY";
                break;
            default:
                _animationOption = "ShakeZ";
                break;
        }
    }

    void Update()
    {
        subtractFreezeTime(Time.deltaTime);
    }

    public void DoAction()
    {
    }
}
