using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchBehaviour : GeneralObservedAction {

    public List<Light> Lights = new List<Light>();

    public bool IsActionDone { get; set; } 
    

	// Use this for initialization
	void Start () {
        ChangeLightsStatus(false);
        _hasAction = true;
        _hasAnimation= false;
    }
	
	// Update is called once per frame
	void Update () {
        subtractFreezeTime(Time.deltaTime);
    }
    public void ChangeLightsStatus( bool enable)
    {
        for (int i = 0; i < Lights.Count; i++)
            Lights[i].enabled = enable;
    }

    public new void DoAction()
    {
        if (IsActionDone) return;
        ChangeLightsStatus(true);
    }
}
