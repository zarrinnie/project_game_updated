using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public State<SaveDataManager> current;
    public LoadState loading = new LoadState();
    public SavingState saving = new SavingState();
    public static string SaveDataPath { get; private set; }
    public SaveData save;

    void Awake()
    {
        SaveDataPath = Application.persistentDataPath + "/savefile.json";
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        current = loading;
        current.EnterState(this);
    }

    void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(State<SaveDataManager> state)
    {
        current = state;
        state.EnterState(this);
    }
}

[Serializable]
public class SaveData
{
    public DateTime TimeSaved = DateTime.Now;

    public List<SerializedHiddenObject> serializedHiddenObjects;
    public List<Level> unlockedLevels;
    public SaveData()
    {
        serializedHiddenObjects = new List<SerializedHiddenObject>();
    }

    public SaveData(List<SerializedHiddenObject> serializedHiddenObjects)
    {
        this.serializedHiddenObjects = serializedHiddenObjects;
    }

    public void UnlockLevel(int buildIndex)
    {
        Level lastLevel = unlockedLevels.Last();

        for (int i = 0; i < unlockedLevels.Count; i++)
        {
            Level current = unlockedLevels[i];
            if (current.buildIndex == buildIndex)
            {
                if (current.Equals(lastLevel))
                {
                    current.unlocked = true;
                }
                else
                {
                    unlockedLevels[i + 1].unlocked = true;
                }
            }
        }
    }

    public override string ToString()
    {
        return string.Format("Savefile with date {0}, and Hidden objects {1}", TimeSaved, serializedHiddenObjects.ToString());
    }
}

[Serializable]
public class Level
{
    public int buildIndex;
    [JsonIgnore]
    public string levelName;
    [JsonProperty]
    public bool Unlocked { get { return unlocked; } set { unlocked = value; } }

    [SerializeField]
    public bool unlocked;

    public Level Unlock()
    {
        return new Level(this.buildIndex, true);
    }

    public Level(int buildIndex, bool unlocked)
    {
        this.buildIndex = buildIndex;
        this.unlocked = unlocked;
    }

}

[Serializable]
public class SerializedHiddenObject
{
    public int id;
    [JsonIgnore]
    public Sprite sprite;
    [JsonIgnore]
    public string name;
    [JsonProperty]
    public bool found { set; get; } = false;

    public override string ToString()
    {
        return "Serialized hidden object with id " + id + (found ? "has been found" : "Not yet found");
    }
}

