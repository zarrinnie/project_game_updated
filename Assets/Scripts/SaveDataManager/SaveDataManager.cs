using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class SaveDataManager : MonoBehaviour
{
    public State<SaveDataManager> current;
    public LoadState loading = new LoadState();
    public SavingState saving = new SavingState();
    public string SaveDataPath { get; private set; }
    public SaveData save;

    void Awake(){
        SaveDataPath = Application.persistentDataPath + "/savefile.json";
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        current = loading;
        current.EnterState(this);
    }

    void Update(){
        current.UpdateState(this);
    }

    public void SwitchState(State<SaveDataManager> state){
        current = state; 
        state.EnterState(this);
    }
}

[Serializable]
public class SaveData {
    public DateTime TimeSaved = DateTime.Now;

    public List<SerializedHiddenObject> serializedHiddenObjects;
    public SaveData(){
        serializedHiddenObjects = new List<SerializedHiddenObject>();
    }

    public SaveData(List<SerializedHiddenObject> serializedHiddenObjects){
        this.serializedHiddenObjects = serializedHiddenObjects;
    }

    public override string ToString()
    {
        return string.Format("Savefile with date {0}, and Hidden objects {1}", TimeSaved, serializedHiddenObjects.ToString());
    }
}

[Serializable]
public class SerializedHiddenObject {
    public int id; 
    [JsonIgnore]
    public Sprite sprite;
    [JsonIgnore]
    public string name;
    [JsonProperty]
    public bool found {set; get;} = false;

    public override string ToString()
    {
        return "Serialized hiddne object with id " + id + (found ? "has been found" : "Not yet found");
    }
}

