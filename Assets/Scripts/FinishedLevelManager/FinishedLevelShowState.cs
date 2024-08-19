using System;
using Core;
using UnityEngine;

[Serializable]
public class FinishedLevelShowState : State<FinishedLevelManager>
{
    private SaveDataManager saveDataManager;
    [SerializeField]
    private DrawerManager drawerManager;
    [SerializeField]
    private GameObject[] stars;
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        finishedLevelManager.canvas.enabled = true;

        foreach(GameObject star in stars){
            star.SetActive(true);
        }


        saveDataManager.saving.drawer = drawerManager;
        saveDataManager.SwitchState(saveDataManager.saving);
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }
}