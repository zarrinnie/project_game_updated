using System;
using Core;

[Serializable]
public class ExplanationIdleState : State<ExplanationManager>
{
    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.canvas.enabled = false;

        if (!explanationMenu.isMainMenu)
        {
            // Turn on clock, to its last state before it was disabled
            explanationMenu.clock.SwitchState(explanationMenu.clock.lastState);

            if (explanationMenu.item != null)
            {
                // Disable the item and re-enable the drawer
                explanationMenu.item.SwitchState(explanationMenu.item.disabled);
                explanationMenu.item.Explained = true;
            }
            explanationMenu.drawer.SwitchState(explanationMenu.drawer.idleState);
        }
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
    }
}