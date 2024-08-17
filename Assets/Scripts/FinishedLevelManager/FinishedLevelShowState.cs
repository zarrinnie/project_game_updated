using System;
using UnityEngine;

[Serializable]
public class FinishedLevelShowState : FinishedLevelBaseState
{
    private SaveDataManager saveDataManager;
    [SerializeField]
    private DrawerManager drawerManager;
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        finishedLevelManager.canvas.enabled = true;
        saveDataManager.saving.drawer = drawerManager;
        saveDataManager.SwitchState(saveDataManager.saving);
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }
}