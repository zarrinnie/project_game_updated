using System;
using System.Collections;
using Core;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
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

        // Cast a Ray on left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // To see where the ray goes
            Debug.DrawRay(ray.origin, ray.direction * 10);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Collider has been hit
            if (hit.collider != null && hit.collider.Equals(gameObject.GetComponent<BoxCollider2D>())){
                SwitchState(transitionState);
            }
        }
        currentState.UpdateState(this);
    }

    public void SwitchState(State<HiddenObjectManager> state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
