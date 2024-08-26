using Core;
using UnityEngine;
using UnityEngine.UI;

public class ClockNormalState : State<ClockManager>
{
    public override void EnterState(ClockManager clock)
    {
        clock.clockImageComponent.sprite = clock.clockStates[0].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.isLessThanLimit(1)){
            clock.SwitchState(clock.agitated);
        }
    }
}