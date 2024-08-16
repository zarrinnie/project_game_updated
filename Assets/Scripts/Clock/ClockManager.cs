using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public ClockBaseState currentState;
    public ClockBaseState lastState = new ClockNormalState();
    public ClockNormalState normal = new ClockNormalState();
    public ClockUncalmState uncalm = new ClockUncalmState();
    public ClockAgitatedState agitated = new ClockAgitatedState();
    public ClockPausedState paused = new ClockPausedState();

    public TextMeshProUGUI clockText;
    public ClockState[] clockStates = new ClockState[3];
    public TimeSpan timer = TimeSpan.FromMinutes(5);
    [NonSerialized]
    public float timePassed = 0;

    [NonSerialized]
    public Sprite clockSprite;

    [SerializeField]
    private Image clockImageComponent;

    // Start is called before the first frame update
    void Start()
    {
        clockSprite = clockImageComponent.sprite;

        currentState = normal;
        currentState.EnterState(this);

        StartCoroutine(UpdateClock());
    }

    
    void Update(){
        currentState.UpdateState(this);
    }

    // Called every exact second
    void FixedUpdate()
    {
        clockText.SetText(timer.ToString(@"mm\:ss"));
    }

    // Coroutine that updates the clock
    public IEnumerator UpdateClock(){
        // The timer is not done yet
        while(timePassed < (float) timer.TotalSeconds){
            // Time that passed between frames
            timePassed += Time.deltaTime;

            // Subtract and replace new TimeSpan with
            // TimeSpan - 1 second
            timer = timer.Subtract(TimeSpan.FromSeconds(1));

            yield return new WaitForSeconds(1);
        }

        yield break;
    }

    public bool isLessThanLimit(int limitIndex){
        return timer < clockStates[limitIndex].SpanLimit;
    }

    public void SwitchState(ClockBaseState state){
        if(currentState != null && currentState == paused){
            StartCoroutine(UpdateClock());
        }

        currentState = state; 
        currentState.EnterState(this);
    }
}


[Serializable]
public class ClockState {
    [Tooltip("The sprite associated with this state")]
    [SerializeField]
    private Sprite stateSprite;
    [SerializeField]
    [Tooltip("Time limit in seconds")]
    [Range(0.0f, 5 * 60)]
    private float spanLimit;

    public Sprite StateSprite {
        get { 
            return stateSprite;
        }

        set {
            stateSprite = value;
        }
    }

    public TimeSpan SpanLimit {
        get {
            return TimeSpan.FromSeconds(spanLimit);
        }

        set {
            spanLimit = (float) value.TotalSeconds;
        }
    }
}
