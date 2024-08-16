using System;
using UnityEngine;

[Serializable]
public class ClockAgitatedState : ClockBaseState
{
    [SerializeField]
    private FinishedLevelManager finishedLevelManager;
    public override void EnterState(ClockManager clock)
    {
        clock.clockSprite = clock.clockStates[2].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.timer.TotalSeconds == 0){
            finishedLevelManager.SwitchState(finishedLevelManager.shown);
        }
    }
}