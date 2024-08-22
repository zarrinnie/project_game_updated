using System.Collections;
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
        DrawerManager drawer = GameObject.Find("Item_drawer").GetComponent<DrawerManager>();
        foreach(HiddenObjectManager hiddenObject in drawer.hiddenObjects){
            hiddenObject.SwitchState(hiddenObject.transitionState);
            Time.timeScale = 10;
            yield return new WaitForSeconds(1);

            Time.timeScale = 1;
            yield return new WaitForSeconds(1);

            Assert.AreEqual(hiddenObject.currentState, hiddenObject.disabled);
        }

        yield return null;
    }
}