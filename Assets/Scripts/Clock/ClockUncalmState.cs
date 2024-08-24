using Core;

public class ClockUncalmState : State<ClockManager>
{
    public override void EnterState(ClockManager clock)
    {
        clock.clockImageComponent.sprite = clock.clockStates[1].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.isLessThanLimit(2)){
            clock.SwitchState(clock.agitated);
        }
    }
}