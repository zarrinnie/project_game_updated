using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IExplainable : IPointerClickHandler
{
    public Canvas Canvas { get; set; }
    public Sprite DiscoveredSprite { get; set; }
    public TextMeshProUGUI TextMeshPro { get; set; }
    public string Description { get; set; }
    public Animator SpeakerAnimator { get; set; }
    public Animator ScrollBarAnimator { get; set; }
    public bool DoneExplaining { get; set; }
    public List<Link> Links { get; set; }

    public void Idle();
    public void Explain();
    public void CheckInput();
}