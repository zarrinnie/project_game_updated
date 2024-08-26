using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ItemTest
{
    [OneTimeSetUp]
    public void LoadTestScene(){
        SceneManager.LoadScene("Level_UI");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DiscoverItem()
    {
        HiddenObjectManager item = GameObject.Find("Barong mask").GetComponent<HiddenObjectManager>();
        ExplanationManager explanation = GameObject.Find("Explanation_canvas").GetComponent<ExplanationManager>();
        ClockManager clock = GameObject.Find("Clock_panel").GetComponent<ClockManager>();

        item.SwitchState(item.transitionState);

        Assert.AreEqual(item.currentState, item.transitionState);

        yield return new WaitForSeconds(2);

        Assert.AreEqual(explanation.currentState, explanation.explaining);
        Assert.AreEqual(clock.currentState, clock.paused);

        yield return new WaitForSeconds(2);
        Assert.AreEqual(TimeSpan.FromSeconds(299), clock.timer);

        explanation.maxVisibleChars = explanation.item.Description.Length;

        yield return new WaitForSeconds(1);

        Assert.IsTrue(explanation.DoneExplaining);
        Assert.AreEqual(item.Description.Length, explanation.TextMeshPro.text.Length);

        yield return new WaitForSeconds(1);

        explanation.SwitchState(explanation.idle);
        Assert.AreEqual(explanation.currentState, explanation.idle);
        Assert.AreEqual(item.currentState, item.disabled);

        yield return null;
    }
}
