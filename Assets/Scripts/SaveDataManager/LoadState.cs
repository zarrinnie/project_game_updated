using System.Collections.Generic;
using System.IO;
using Core;
using Newtonsoft.Json;
using UnityEditor.Scripting;
using UnityEngine;

public class LoadState : State<SaveDataManager>
{
    public override void EnterState(SaveDataManager saveManager)
    {
        Debug.Log("Loading...");
        Debug.Log(saveManager.SaveDataPath);
        if (!File.Exists(saveManager.SaveDataPath))
        {
            File.WriteAllText(saveManager.SaveDataPath, JsonConvert.SerializeObject(saveManager.save, Formatting.Indented)); 
        }
        else
        {
            // The save data from the savefile
            SaveData newSaveData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(saveManager.SaveDataPath));
            // The deserialized hidden objects
            List<SerializedHiddenObject> deserializedHiddenObjects = newSaveData.serializedHiddenObjects;
            
            for(int i = 0; i < deserializedHiddenObjects.Count; i++){
                Debug.Log(deserializedHiddenObjects[i].found);
                // The two deserialized hidden objects have the same id
                if(deserializedHiddenObjects[i].id == saveManager.save.serializedHiddenObjects[i].id){
                    deserializedHiddenObjects[i].sprite = saveManager.save.serializedHiddenObjects[i].sprite;
                }
            }

            saveManager.save = newSaveData;
        }
    }


    public override void UpdateState(SaveDataManager saveManager)
    {
    }
}