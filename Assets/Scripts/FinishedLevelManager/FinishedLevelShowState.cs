using System;
using Core;
using TMPro;
using UnityEngine;

[Serializable]
public class FinishedLevelShowState : State<FinishedLevelManager>
{
    private SaveDataManager saveDataManager;
    [SerializeField]
    private DrawerManager drawerManager;
    [SerializeField]
    private GameObject[] stars;
    [SerializeField]
    private DrawerManager drawer;
    [SerializeField]
    private TextMeshProUGUI statusText;
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        finishedLevelManager.canvas.enabled = true;

        switch (drawer.score){
            case 1: 
                activateStar(0);
                break;
            case 6: 
                activateStar(1);
                break;
            case 9: 
                activateStar(2);
                break;

            default: 
                statusText.SetText("Failed!");
                break;
        }

        saveDataManager.saving.drawer = drawerManager;
        saveDataManager.SwitchState(saveDataManager.saving);
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }

    public void activateStar(int index){
        stars[index].SetActive(true);
    }
}