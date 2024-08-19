using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    public GameObject levelPanelPrefab;
    private SaveDataManager saveDataManager;
    public List<Level> levels;
    // Start is called before the first frame update
    void Start()
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();

        saveDataManager.save.unlockedLevels.ForEach(level =>
        {
            GameObject instantiatedLevelPanel = Instantiate(levelPanelPrefab, transform);
            Button instantiatedPlayButton = instantiatedLevelPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();
            instantiatedLevelPanel.name = level.levelName;

            instantiatedLevelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(instantiatedLevelPanel.name);
            instantiatedPlayButton.onClick.AddListener(() => SceneManager.LoadScene(level.buildIndex));

            if (!level.unlocked)
            {
                instantiatedLevelPanel.transform.GetChild(2).gameObject.SetActive(true);
                instantiatedPlayButton.enabled = false;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}