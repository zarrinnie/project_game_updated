using System;
using System.Collections;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ExplanationExplainState : State<ExplanationManager>
{
    [SerializeField]
    private Animator speakerAnimator;
    [SerializeField]
    private Animator scrollbarAnimator;
    [SerializeField]
    private TextMeshProUGUI content;
    public TextMeshProUGUI Content
    {
        get
        {
            return content;
        }

        set
        {
            content = value;
        }
    }
    [SerializeField]
    private float explanationSpeed = 0.05f;
    [SerializeField]
    private float extraDelayOnSpace = 1.0f;
    [SerializeField]
    private Image discoveredImageComponent;
    public int maxVisibleChars { get; set; }
    public bool doneExplaining { get; private set; }

    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.canvas.enabled = true;
        discoveredImageComponent.sprite = explanationMenu.item.GetComponent<SpriteRenderer>().sprite;
        if (!explanationMenu.isMainMenu)
        {
            content.SetText(explanationMenu.item.Description);
            explanationMenu.clock.SwitchState(explanationMenu.clock.paused);
        } else {
            content.SetText(explanationMenu.AltDesc);
        }
        explanationMenu.StartCoroutine(TypeWrite(explanationMenu));

    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
        // Pressed escape and not yet done explaining
        if (Input.GetKeyDown(KeyCode.Escape) && !doneExplaining)
        {
            explanationMenu.StopAllCoroutines();
            content.maxVisibleCharacters = explanationMenu.isMainMenu ? explanationMenu.AltDesc.Length : explanationMenu.item.Description.Length;
            maxVisibleChars = content.maxVisibleCharacters + 1;
            doneExplaining = true;
        }
        else if (doneExplaining && Input.GetKeyDown(KeyCode.Escape))
        {
            // Pressed escape and done explaining
            explanationMenu.SwitchState(explanationMenu.idle);
        }

        if(doneExplaining){
            Debug.Log("Show");
            scrollbarAnimator.SetBool("Appear", true);
        }
    }

    public IEnumerator TypeWrite(ExplanationManager explanationMenu)
    {
        int remaining = explanationMenu.isMainMenu ? explanationMenu.AltDesc.Length : explanationMenu.item.Description.Length;
        while (maxVisibleChars < remaining)
        {
            maxVisibleChars += 1;
            content.maxVisibleCharacters = maxVisibleChars;

            // The current character is a space
            if (content.textInfo.characterInfo[maxVisibleChars].character == ' ')
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