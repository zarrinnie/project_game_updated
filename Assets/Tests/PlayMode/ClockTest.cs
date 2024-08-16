using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ClockTest : LevelTest
{
    [UnityTest]
    public IEnumerator ClockChangesEverySecond()
    {
        ClockManager clock = GameObject.Find("Clock_panel").GetComponent<ClockManager>();

        Assert.IsTrue(TimeSpan.FromSeconds(299) == clock.timer);
        yield return null;
    }

    [UnityTest]
    public IEnumerator PauseClock(){
        ClockManager clock = GameObject.Find("Clock_panel").GetComponent<ClockManager>();
        clock.SwitchState(clock.paused);

        yield return new WaitForSeconds(1);

        Assert.AreEqual(clock.paused, clock.currentState);

        yield return new WaitForSeconds(2);

        Assert.AreEqual(clock.timer, TimeSpan.FromSeconds(299));
    }

    [UnityTest]
    public IEnumerator ShowFinishedLevelMenu(){
        ClockManager clock = GameObject.Find("Clock_panel").GetComponent<ClockManager>();
        FinishedLevelManager finishedLevelManager = GameObject.Find("FinishedLevel_canvas").GetComponent<FinishedLevelManager>();

        clock.SwitchState(clock.normal);
        clock.timer = clock.clockStates[0].SpanLimit - TimeSpan.FromSeconds(1);
        yield return new WaitForSeconds(1);

        Assert.AreEqual(clock.currentState, clock.uncalm);

        clock.timer = clock.clockStates[1].SpanLimit - TimeSpan.FromSeconds(1);

        yield return new WaitForSeconds(1);
        Assert.AreEqual(clock.currentState, clock.agitated);

        clock.timer = TimeSpan.Zero;
        yield return new WaitForSeconds(1);

        Assert.AreEqual(finishedLevelManager.shown, finishedLevelManager.current);
    }
}
