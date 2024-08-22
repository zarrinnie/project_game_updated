using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedLevelController : MonoBehaviour
{
    [SerializeField]
    private ExplanationManager explanationManager;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private Sprite pausedSprite;
    [SerializeField]
    private ClockManager clockManager;
    [SerializeField]
    private Sprite playingSprite;
    private Image pauseButtonImageComponent;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        pauseButtonImageComponent = pauseButton.GetComponent<Image>();
        pauseButtonImageComponent.sprite = pausedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && explanationManager.currentState == explanationManager.idle){
            TogglePaused();
        }
    }

    public void TogglePaused(){
        canvas.enabled = !canvas.enabled;
        if(clockManager.currentState.Equals(clockManager.paused)){
            clockManager.SwitchState(clockManager.lastState);
        } else {
            clockManager.SwitchState(clockManager.paused);
        }

        pauseButtonImageComponent.sprite = pauseButtonImageComponent.sprite.Equals(pausedSprite) ? playingSprite : pausedSprite;
    }
}
