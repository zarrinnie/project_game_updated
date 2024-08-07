using UnityEngine;

public class HiddenObjectDisabled: HiddenObjectBaseState {
    public override void EnterState(HiddenObjectManager item)
    {
        Debug.Log("Disabiling obj");
        item.Hidden = false;
    }

    public override void UpdateState(HiddenObjectManager item)
    {
    }
}