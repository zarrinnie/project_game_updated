public class ExplanationIdleState : ExplanationBaseState
{
    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.levelUIManager.SwitchState(explanationMenu.levelUIManager.idle);
        explanationMenu.canvas.enabled = false;
        explanationMenu.clock.SwitchState(explanationMenu.clock.lastState);
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
    }
}