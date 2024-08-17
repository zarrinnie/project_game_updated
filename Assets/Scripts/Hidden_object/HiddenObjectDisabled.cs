using Core;
using UnityEngine;

public class HiddenObjectDisabled: State<HiddenObjectManager> {
    public override void EnterState(HiddenObjectManager item)
    {
        Debug.Log("Disabiling obj");
        item.Hidden = false;
    }

    public override void UpdateState(HiddenObjectManager item)
    {
    }
}