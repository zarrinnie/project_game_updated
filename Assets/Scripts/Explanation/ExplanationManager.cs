using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExplanationManager : MonoBehaviour, IExplainable
{
    public State<IExplainable> currentState;
    public ExplanationIdleState idle = new ExplanationIdleState();
    public ExplanationExplainState explaining = new ExplanationExplainState();

    public Canvas Canvas { get { return canvas; } set { canvas = value; } }
    public Sprite DiscoveredSprite { get { return discoveredSprite; } set { discoveredSprite = value; } }
    public TextMeshProUGUI TextMeshPro { get { return textMeshPro; } set { textMeshPro = value; } }
    public string Description { get { return description; } set { description = value; } }
    public Animator SpeakerAnimator { get { return speakerAnimator; } set { speakerAnimator = value; } }
    public Animator ScrollBarAnimator { get { return scrollBarAnimator; } set { scrollBarAnimator = value; } }
    public List<Link> Links { get { return links; } set { links = value; } }
    public bool DoneExplaining { get { return doneExplaining; } set { doneExplaining = value; } }
    public int maxVisibleChars { get; set; }

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Sprite discoveredSprite;
    [SerializeField]
    private Image discoveredImageComponent;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private Animator speakerAnimator;
    [SerializeField]
    private Animator scrollBarAnimator;
    [SerializeField]
    private float explanationSpeed = 0.05f;
    [SerializeField]
    private float extraDelayOnSpace = 1.0f;
    [SerializeField]
    private List<Link> links;
    private bool doneExplaining;
    private string description;
    public ClockManager clock;
    public DrawerManager drawer;
    public HiddenObjectManager item;

    void Start()
    {
        currentState = idle;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(State<IExplainable> state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void Idle()
    {
        canvas.enabled = false;

        // Turn on clock, to its last state before it was disabled
        clock.SwitchState(clock.lastState);

        if (item != null)
        {
            // Disable the item and re-enable the drawer
            item.SwitchState(item.disabled);
            item.Explained = true;
        }
        drawer.SwitchState(drawer.idleState);
    }

    public void CheckInput()
    {
        // Pressed escape and not yet done explaining
        if (Input.GetKeyDown(KeyCode.Escape) && !doneExplaining)
        {
            StopAllCoroutines();
            textMeshPro.maxVisibleCharacters = description.Length;
            maxVisibleChars = textMeshPro.maxVisibleCharacters + 1;
            doneExplaining = true;
        }
        else if (doneExplaining && Input.GetKeyDown(KeyCode.Escape))
        {
            // Pressed escape and done explaining
            SwitchState(idle);
        }

        if (doneExplaining)
        {
            Debug.Log("Show");
            scrollBarAnimator.SetBool("Appear", true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TextUtils.OpenLink(textMeshPro, Links);
    }

    public void Explain()
    {
        canvas.enabled = true;
        textMeshPro.SetText(item.Description);
        clock.SwitchState(clock.paused);
        discoveredImageComponent.sprite = item.GetComponent<SpriteRenderer>().sprite;
        description = item.Description;
        StartCoroutine(TypeWrite());
    }

    public IEnumerator TypeWrite()
    {
        int remaining = description.Length;
        while (maxVisibleChars < remaining)
        {
            maxVisibleChars += 1;
            textMeshPro.maxVisibleCharacters = maxVisibleChars;

            // The current character is a space
            if (textMeshPro.textInfo.characterInfo[maxVisibleChars].character == ' ')
            {
                speakerAnimator.Play("Idle");
                yield return new WaitForSeconds(explanationSpeed + extraDelayOnSpace);
            }
            else
            {
                speakerAnimator.Play("Talking");
                yield return new WaitForSeconds(explanationSpeed);
            }
        }

        doneExplaining = true;

        yield break;
    }
}