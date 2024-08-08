
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ExplanationExplainState : ExplanationBaseState
{
    [SerializeField]
    private Animator speakerAnimator;
    [SerializeField]
    private TextMeshProUGUI content;
    [SerializeField]
    private float explanationSpeed = 0.05f;
    [SerializeField]
    private float extraDelayOnSpace = 1.0f;
    private int maxVisibleChars;
    private bool doneExplaining;

    public override void EnterState(ExplanationManager explanationMenu)
    {
        explanationMenu.canvas.enabled = true;
        explanationMenu.levelUIManager.SwitchState(explanationMenu.levelUIManager.blurred);
        explanationMenu.clock.SwitchState(explanationMenu.clock.paused);

        content.SetText(explanationMenu.item.Description);

        explanationMenu.StartCoroutine(TypeWrite(explanationMenu));
    }

    public override void UpdateState(ExplanationManager explanationMenu)
    {
        // Pressed escape and not yet done explaining
        if(Input.GetKeyDown(KeyCode.Escape) && !doneExplaining){
            explanationMenu.StopAllCoroutines();
            content.maxVisibleCharacters = explanationMenu.item.Description.Length;
            doneExplaining = true;
        } else if(doneExplaining && Input.GetKeyDown(KeyCode.Escape)){
            // Pressed escape and done explaining
            explanationMenu.SwitchState(explanationMenu.idle);
        }
    }

    public IEnumerator TypeWrite(ExplanationManager explanationMenu)
    {
        while (maxVisibleChars < explanationMenu.item.Description.Length)
        {
            maxVisibleChars += 1;
            content.maxVisibleCharacters = maxVisibleChars;

            // The current character is a space
            if (content.textInfo.characterInfo[maxVisibleChars].character == ' ')
            {
                speakerAnimator.Play("Talking");
                yield return new WaitForSeconds(explanationSpeed + extraDelayOnSpace);
            }
            else
            {
                speakerAnimator.Play("Idle");
                yield return new WaitForSeconds(explanationSpeed);
            }
        }

        doneExplaining = true;

        yield break;
    }
}