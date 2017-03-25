using UnityEngine;
using System.Collections;
using System;

public class GeneralObservedAction : MonoBehaviour, IObservedAction
{
    public bool isObservable
    {
        get { return _FreezeTime <= 0; }
    }

    public int AnimationOption = 1;

    private float _FreezeTime = 0;
    private string _animationOption;
    public void BeingObserved() 
    {
        this.GetComponent<Animator>().SetBool(_animationOption, true);
    }

    public void Idle()
    {
    }

    public void StopedBeingObserved()
    {
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
        switch(AnimationOption)
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
}
