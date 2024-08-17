using System;
using System.Collections;
using Core;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HiddenObjectManager : MonoBehaviour
{
    public State<HiddenObjectManager> currentState;
    public HiddenObjectIdle idleState = new HiddenObjectIdle();
    public HiddenObjectTransition transitionState = new HiddenObjectTransition();
    public HiddenObjectDisabled disabled = new HiddenObjectDisabled();
    public HiddenObjectHighlighted highlighted;

    public ExplanationManager explanationManager;

    public int id;

    public string Description
    {
        get; private set;
    }

    private int index;
    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = Index;
        }
    }

    private bool hidden = true;
    public bool Hidden
    {
        get
        {
            return hidden;
        }

        set
        {
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
        TextAsset descriptionAsset = Resources.Load<TextAsset>(gameObject.name);
        if(descriptionAsset == null){
            Debug.LogError(string.Format("Please make a description asset named {} in the Resources folder", name));
        } else {
            Description = descriptionAsset.text;
        }

        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(State<HiddenObjectManager> state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
