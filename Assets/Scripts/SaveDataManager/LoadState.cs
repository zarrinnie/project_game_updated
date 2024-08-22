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
        if (!File.Exists(SaveDataManager.SaveDataPath))
        {
            File.WriteAllText(SaveDataManager.SaveDataPath, JsonConvert.SerializeObject(saveManager.save, Formatting.Indented));
        }
        else
        {
            // The save data from the savefile
            SaveData newSaveData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(SaveDataManager.SaveDataPath));
            // The deserialized hidden objects
            List<SerializedHiddenObject> deserializedHiddenObjects = newSaveData.serializedHiddenObjects;
            List<Level> deserializedLevels = newSaveData.unlockedLevels;

            for (int i = 0; i < deserializedHiddenObjects.Count; i++)
            {
                Debug.Log(deserializedHiddenObjects[i].found);
                // The two deserialized hidden objects have the same id
                if (deserializedHiddenObjects[i].id == saveManager.save.serializedHiddenObjects[i].id)
                {
                    deserializedHiddenObjects[i].sprite = saveManager.save.serializedHiddenObjects[i].sprite;
                    deserializedHiddenObjects[i].name = saveManager.save.serializedHiddenObjects[i].name;
                }
            }

            for (int i = 0; i < deserializedLevels.Count; i++)
            {
                if (deserializedLevels[i].buildIndex == saveManager.save.unlockedLevels[i].buildIndex)
                {
                    deserializedLevels[i].levelName = saveManager.save.unlockedLevels[i].levelName;
                }
            }

            saveManager.save = newSaveData;
        }
    }


    public override void UpdateState(SaveDataManager saveManager)
    {
    }
}