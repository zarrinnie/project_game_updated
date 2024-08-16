using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

public class HintTest : LevelTest {
    [UnityTest]
    public IEnumerator showHint(){
        HintPanelManager hintPanelManager = GameObject.Find("Hint-panel").GetComponent<HintPanelManager>();
        hintPanelManager.GetHint();

        yield return new WaitForSeconds(0.1f);

        Assert.IsFalse(hintPanelManager.hintButton.interactable);

        // yield return new WaitForSeconds(3f);
        // Assert.AreEqual(hintPanelManager.garudaBird.transform.position, hintPanelManager.drawer.hiddenObjects[hintPanelManager.randIndex].transform.position);

        yield return new WaitForSeconds(10);
        Assert.AreEqual(hintPanelManager.garudaBird.transform.position, hintPanelManager.transform.position);
    }
}