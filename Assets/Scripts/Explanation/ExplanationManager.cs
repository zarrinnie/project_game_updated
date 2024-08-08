using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ExplanationManager : MonoBehaviour {
    public ExplanationBaseState currentState;
    public ExplanationIdleState idle = new ExplanationIdleState();
    public ExplanationExplainState explaining = new ExplanationExplainState();

    public LevelUIManager levelUIManager;
    public Canvas canvas;
    public ClockManager clock;
    public DrawerManager drawer;
    [NonSerialized]
    public HiddenObjectManager item;
    private string[] descriptions;
    public string[] Descriptions {
        get {
            return descriptions;
        }

        set {
            descriptions = value;
        }
    }

    void Start(){
        canvas = gameObject.GetComponent<Canvas>();

        currentState = idle;
        currentState.EnterState(this);
    }

    void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(ExplanationBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }
}