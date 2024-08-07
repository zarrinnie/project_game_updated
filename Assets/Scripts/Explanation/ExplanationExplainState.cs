
using UnityEngine;

public class ExplanationExplainState : ExplanationBaseState
{
    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.canvas.enabled = true;
        explanationMenu.levelUIManager.SwitchState(explanationMenu.levelUIManager.blurred);
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
    }
}