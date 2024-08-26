using System;
using Core;

[Serializable]
public class ExplanationIdleState : State<IExplainable>
{
    public override void EnterState(IExplainable explainable)
    {
        explainable.Idle();
    }

    public override void UpdateState(IExplainable explainable)
    {
    }
}