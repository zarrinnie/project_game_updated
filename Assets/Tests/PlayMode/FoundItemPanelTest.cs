using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class FoundItemPanelTest: GameTest {
    [UnityTest]
    public IEnumerator AreDrawersSameAsFoundObjects() {
        File.Delete(SaveDataManager.SaveDataPath);
        GameObject mainMenu = GameObject.Find("Main_UI");

        SaveDataManager saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        SceneController sceneController = mainMenu.GetComponent<SceneController>();
        GameObject levelsPane = GameObject.Find("Levels");
        yield return new WaitForSeconds(1);
        Assert.IsTrue(levelsPane.activeInHierarchy);

        yield return new WaitForSeconds(1);

        LevelPanelController levelsPanel = GameObject.Find("Levels_panel").GetComponent<LevelPanelController>();
        List<HiddenObjectManager> hiddenObjects = new List<HiddenObjectManager>();

        for(int i = 0; i < 0; i++){
            Debug.Log("Testing buttons");
            levelsPanel.enabledButtons[i].onClick.Invoke();

            yield return new WaitForSeconds(2);

            GameObject currentDrawer = GameObject.Find("Item_drawer");
            DrawerManager currentDrawerManager = currentDrawer.GetComponent<DrawerManager>();
            foreach(HiddenObjectManager hiddenObject in currentDrawerManager.hiddenObjects){
                hiddenObjects.Add(hiddenObject);
            }
            yield return new WaitForSeconds(2);
        }

        Assert.AreEqual(hiddenObjects.Count, saveDataManager.save.serializedHiddenObjects.Count);

        SceneManager.LoadScene("Main_menu");
        yield return new WaitForSeconds(2);


        mainMenu = GameObject.Find("Main_UI");
        sceneController = mainMenu.GetComponent<SceneController>();

        sceneController.ShowThing(1);
        GameObject foundObjectsPane = GameObject.Find("Found_objects");

        Assert.IsTrue(foundObjectsPane.activeInHierarchy);
        Assert.AreEqual(foundObjectsPane.transform.childCount, saveDataManager.save.serializedHiddenObjects.Count);





        yield return null;
    } 

}