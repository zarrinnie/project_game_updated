using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor.Scripting;
using UnityEngine;

public class LoadState : SaveDataBaseState
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
            saveManager.save = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(saveManager.SaveDataPath)); 
            Debug.Log(saveManager.save);
        }
    }


    public override void UpdateState(SaveDataManager saveManager)
    {
    }
}