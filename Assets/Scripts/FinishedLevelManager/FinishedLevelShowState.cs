using System;
using UnityEngine;

[Serializable]
public class FinishedLevelShowState : FinishedLevelBaseState
{
    [SerializeField]
    private SaveDataManager saveDataManager;
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        finishedLevelManager.canvas.enabled = true;
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }
}