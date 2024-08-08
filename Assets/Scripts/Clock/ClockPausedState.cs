using UnityEngine;

public class ClockPausedState : ClockBaseState
{
    public override void EnterState(ClockManager clock)
    {
        Debug.Log("Pausing clock");
        clock.StopAllCoroutines();
    }

    public override void UpdateState(ClockManager clock)
    {
    }
}