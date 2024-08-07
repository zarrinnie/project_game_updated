using UnityEngine;

public class LevelUIBlurState : LevelUIBaseState
{
    public override void EnterState(LevelUIManager levelUi)
    {
        levelUi.ToggleBlur();
    }

    public override void UpdateState(LevelUIManager levelUi)
    {
    }
}