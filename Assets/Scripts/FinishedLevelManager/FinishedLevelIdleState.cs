using UnityEngine;

public class FinishedLevelIdleState : FinishedLevelBaseState
{
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        finishedLevelManager.canvas.enabled = false;
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }
}