using System;
using Core;
using UnityEngine;

[Serializable]
public class FinishedLevelShowState : State<FinishedLevelManager>
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