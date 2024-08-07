using UnityEngine;

public abstract class HiddenObjectBaseState {
    public abstract void EnterState(HiddenObjectManager item);
    public abstract void UpdateState(HiddenObjectManager item);

}