using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SavingState : SaveDataBaseState
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
        Debug.Log(JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(manager.SaveDataPath)));
        File.WriteAllText(manager.SaveDataPath, JsonConvert.SerializeObject(manager.save));

        manager.SwitchState(manager.loading);
    }

    public override void UpdateState(SaveDataManager manager)
    {
    }
}