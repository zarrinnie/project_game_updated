using Core;
using UnityEngine;

public class ExplanationManager : MonoBehaviour {
    public State<ExplanationManager> currentState;
    public ExplanationIdleState idle = new ExplanationIdleState();
    public ExplanationExplainState explaining = new ExplanationExplainState();

    public Canvas canvas;
    public ClockManager clock;
    public DrawerManager drawer;
    public HiddenObjectManager item;
    public string AltDesc { get; set; }
    
    public bool isMainMenu { get; set; }

    void Start(){
        canvas = gameObject.GetComponent<Canvas>();

        currentState = idle;
        currentState.EnterState(this);
    }

    void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(State<ExplanationManager> state){
        currentState = state;
        currentState.EnterState(this);
    }
}