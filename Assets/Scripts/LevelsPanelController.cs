using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    public List<Level> Levels;
    public GameObject levelPanelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Levels.ForEach(level =>
        {
            GameObject instantiatedLevelPanel = Instantiate(levelPanelPrefab, transform);
            instantiatedLevelPanel.name = "Level " + level.Index;

            instantiatedLevelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(instantiatedLevelPanel.name);
            instantiatedLevelPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level_UI"));
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[Serializable]
public class Level
{
    [SerializeField]
    private int index;
    public int Index { get { return index; } set { index = value; } }
}