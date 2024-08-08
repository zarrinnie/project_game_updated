
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ExplanationExplainState : ExplanationBaseState
{
    [SerializeField]
    private TextMeshProUGUI content;
    [SerializeField]
    private float explanationSpeed = 0.05f;
    private int maxVisibleChars;

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
        if(Input.GetKeyDown(KeyCode.Escape)){
            explanationMenu.SwitchState(explanationMenu.idle);
        }

    }

    public IEnumerator TypeWrite(ExplanationManager explanationMenu){
        while(maxVisibleChars < explanationMenu.item.Description.Length){
            maxVisibleChars += 1;
            content.maxVisibleCharacters = maxVisibleChars;
            yield return new WaitForSeconds(explanationSpeed);
        }

        yield break;
    }
}