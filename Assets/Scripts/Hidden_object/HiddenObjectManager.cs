using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiddenObjectManager : MonoBehaviour
{
    HiddenObjectBaseState currentState;
    public HiddenObjectIdle idleState = new HiddenObjectIdle();
    public HiddenObjectTransition transitionState = new HiddenObjectTransition();
    public HiddenObjectDisabled disabled = new HiddenObjectDisabled();

    public ExplanationManager explanationManager; 
    
    public DrawerManager drawer;

    private int index;
    public int Index {
        get {
            return index;
        }

        set {
            index = Index;
        }
    }

    private bool hidden = true;
    public bool Hidden
    {
        get {
            return hidden;
        }

        set {
            hidden = value;
        }
    }

    public bool Explained
    {
        get; set;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

    }

    public void SwitchState(HiddenObjectBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
