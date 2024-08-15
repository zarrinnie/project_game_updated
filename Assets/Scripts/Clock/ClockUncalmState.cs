public class ClockUncalmState : ClockBaseState
{
    public override void EnterState(ClockManager clock)
    {
        clock.clockSprite = clock.clockStates[1].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
        if(clock.isLessThanLimit(1)){
            clock.SwitchState(clock.agitated);
        }
    }
}