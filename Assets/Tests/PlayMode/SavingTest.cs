using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SavingTest {
    [OneTimeSetUp]
    public void LoadTestScene(){
        SceneManager.LoadScene("Main_menu");
        SceneManager.LoadScene("Level_UI");
    }

    [UnityTest]
    public IEnumerator Saving(){
        SaveDataManager saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        DrawerManager drawer = GameObject.Find("Item_drawer").GetComponent<DrawerManager>();
        ExplanationManager explanation = GameObject.Find("Explanation_canvas").GetComponent<ExplanationManager>();

        foreach(HiddenObjectManager hiddenObject in drawer.hiddenObjects){
            hiddenObject.SwitchState(hiddenObject.transitionState);

            yield return new WaitForSeconds(1);
            explanation.maxVisibleChars = explanation.item.Description.Length;

            yield return new WaitForSeconds(1);
            explanation.SwitchState(explanation.idle);
        }

        yield return new WaitForSeconds(1);
        Assert.AreEqual(saveDataManager.save.unlockedLevels.Count(unlockedLevel => unlockedLevel.unlocked), 1);


        yield return null;
    }
}