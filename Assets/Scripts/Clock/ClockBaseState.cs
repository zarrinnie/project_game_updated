using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClockBaseState
{
    public abstract void EnterState(ClockManager clock);
    public abstract void UpdateState(ClockManager clock);
}
