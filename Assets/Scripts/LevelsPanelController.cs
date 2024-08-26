using System;
using System.Collections;
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
    public List<Button> enabledButtons;

    // Start is called before the first frame update
    void Start()
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();

        saveDataManager.save.unlockedLevels.ForEach(level =>
        {
            GameObject instantiatedLevelPanel = Instantiate(levelPanelPrefab, transform);
            Image instantiatedLockImage = instantiatedLevelPanel.transform.GetChild(2).GetComponent<Image>();
            Animator instantiatedAnimator = instantiatedLevelPanel.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
            Button instantiatedPlayButton = instantiatedLevelPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();

            // The name of the level
            instantiatedLevelPanel.name = level.levelName;

            instantiatedLevelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(instantiatedLevelPanel.name);
            instantiatedPlayButton.onClick.AddListener(() => StartCoroutine(Zoom(instantiatedAnimator, level)));

            enabledButtons.Add(instantiatedPlayButton);

            if (!level.unlocked)
            {
                instantiatedLevelPanel.transform.GetChild(2).gameObject.SetActive(true);
                instantiatedLockImage.sprite = lockSprite;
                instantiatedLockImage.color = lockColor;
                instantiatedPlayButton.enabled = false;
            }
        });
    }

    public IEnumerator Zoom(Animator animator, Level level)
    {
        animator.SetBool("Zoom", true);
        // Improve this
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level.buildIndex);
    }
}