using System;
using Core;
using UnityEngine;

[Serializable]
public class ClockAgitatedState : State<ClockManager> 
{
    [SerializeField]
    private FinishedLevelManager finishedLevelManager;
    public override void EnterState(ClockManager clock)
    {
        clock.clockImageComponent.sprite = clock.clockStates[2].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.timer.TotalSeconds == 0){
            finishedLevelManager.SwitchState(finishedLevelManager.shown);
        }
    }
}