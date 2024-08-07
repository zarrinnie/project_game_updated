public class ExplanationIdleState : ExplanationBaseState
{
    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.levelUIManager.SwitchState(explanationMenu.levelUIManager.idle);
        explanationMenu.canvas.enabled = false;
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
    }
}