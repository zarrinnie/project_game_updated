using Core;
using UnityEngine;

public class HiddenObjectDisabled: State<HiddenObjectManager> {
    public override void EnterState(HiddenObjectManager item)
    {
        item.Hidden = false;
        item.GetComponent<Animator>().SetBool("Disable", true);
    }

    public override void UpdateState(HiddenObjectManager item)
    {
    }
}