using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject levelPanelPrefab;
    private SaveDataManager saveDataManager;
    [SerializeField]
    private Sprite lockSprite;
    [SerializeField]
    private Color lockColor;

    // Start is called before the first frame update
    void Start()
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();

        saveDataManager.save.unlockedLevels.ForEach(level =>
        {
            GameObject instantiatedLevelPanel = Instantiate(levelPanelPrefab, transform);
            Image instantiatedImage = instantiatedLevelPanel.transform.GetChild(2).GetComponent<Image>();
            Button instantiatedPlayButton = instantiatedLevelPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();

            // The name of the level
            instantiatedLevelPanel.name = level.levelName;

            instantiatedLevelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(instantiatedLevelPanel.name);
            instantiatedPlayButton.onClick.AddListener(() => SceneManager.LoadScene(level.buildIndex));

            if (!level.unlocked)
            {
                instantiatedLevelPanel.transform.GetChild(2).gameObject.SetActive(true);
                instantiatedImage.sprite = lockSprite; 
                instantiatedImage.color = lockColor;
                instantiatedPlayButton.enabled = false;
            }
        });
    }
}