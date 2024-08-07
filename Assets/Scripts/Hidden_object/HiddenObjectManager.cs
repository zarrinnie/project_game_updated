using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiddenObjectManager : MonoBehaviour
{
    HiddenObjectBaseState currentState;
    public HiddenObjectIdle idleState = new HiddenObjectIdle();
    public HiddenObjectTransition transitionState = new HiddenObjectTransition();


    private bool isHidden = true;
    private bool explained = false;

    private TextMeshProUGUI textLabel;

    public TextMeshProUGUI TextLabel
    {
        get; set;
    }

    public bool Hidden
    {
        get; set;
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
