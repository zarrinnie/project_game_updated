using UnityEngine.SceneManagement;

public class ClockAgitatedState : ClockBaseState
{
    public override void EnterState(ClockManager clock)
    {
        clock.clockSprite = clock.clockStates[2].StateSprite;
        clock.lastState = this;
    }

    public override void UpdateState(ClockManager clock)
    {
    }
}