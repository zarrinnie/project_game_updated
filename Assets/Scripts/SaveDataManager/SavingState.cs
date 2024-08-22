using System.Collections.Generic;
using System.IO;
using Core;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingState : State<SaveDataManager>
{
    public DrawerManager drawer;
    public override void EnterState(SaveDataManager manager)
    {
        for(int i = 0; i < drawer.hiddenObjects.Length; i++){
            SerializedHiddenObject currentDeserializedObject = manager.save.serializedHiddenObjects[i];
            HiddenObjectManager hiddenObjectToCompare = drawer.hiddenObjects[i];

            if(hiddenObjectToCompare.id == currentDeserializedObject.id){
                currentDeserializedObject.found = hiddenObjectToCompare.Explained;
            }
        }

        manager.save.UnlockLevel(SceneManager.GetActiveScene().buildIndex);

        Debug.Log(JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(SaveDataManager.SaveDataPath)));
        File.WriteAllText(SaveDataManager.SaveDataPath, JsonConvert.SerializeObject(manager.save));

        manager.SwitchState(manager.loading);
    }

    public override void UpdateState(SaveDataManager manager)
    {
    }
}