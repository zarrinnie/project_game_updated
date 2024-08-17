using Core;
using UnityEngine;

public class FinishedLevelIdleState : State<FinishedLevelManager>
{
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        finishedLevelManager.canvas.enabled = false;
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }
}