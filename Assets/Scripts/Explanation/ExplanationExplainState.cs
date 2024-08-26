using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class ExplanationExplainState : State<IExplainable>  
{
    public override void EnterState(IExplainable explanationMenu)
    {
        explanationMenu.Explain();
    }

    public override void UpdateState(IExplainable explanationMenu)
    {
        explanationMenu.CheckInput();
    }
}