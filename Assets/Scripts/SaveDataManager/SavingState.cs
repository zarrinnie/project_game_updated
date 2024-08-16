using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SavingState : SaveDataBaseState
{
    public override void EnterState(SaveDataManager manager)
    {
        Debug.Log(JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(manager.SaveDataPath)));
        File.WriteAllText(manager.SaveDataPath, JsonConvert.SerializeObject(manager.save));
    }

    public override void UpdateState(SaveDataManager manager)
    {
    }
}