using Core;
using UnityEngine;
using UnityEngine.UI;

public class ClockNormalState : State<ClockManager>
{
    private int index = 0;
    public override void EnterState(ClockManager clock)
    {
        clock.clockSprite = clock.clockStates[index].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.isLessThanLimit(index)){
            clock.SwitchState(clock.uncalm);
        }
    }
}