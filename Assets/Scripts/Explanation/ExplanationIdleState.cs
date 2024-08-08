using System;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class ExplanationIdleState : ExplanationBaseState
{
    public override void EnterState(ExplanationManager explanationMenu)
    {
        // Disable the explanation canvas and blur effect
        explanationMenu.levelUIManager.SwitchState(explanationMenu.levelUIManager.idle);
        explanationMenu.canvas.enabled = false;

        // Turn on clock, to its last state before it was disabled
        explanationMenu.clock.SwitchState(explanationMenu.clock.lastState);

        // Disable the item and re-enable the drawer
        if(explanationMenu.item != null){
            explanationMenu.item.SwitchState(explanationMenu.item.disabled);
            explanationMenu.item.Explained = true;
        }
        explanationMenu.drawer.SwitchState(explanationMenu.drawer.idleState);
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
    }
}