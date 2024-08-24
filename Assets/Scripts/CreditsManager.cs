using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsManager : MonoBehaviour, ITypewritable {
    [SerializeField]
    private TextAsset textToShow;
    
    [SerializeField]
    private float characterDelay = 0.01f;
    private List<Link> links = new List<Link>{
        new Link("Ayadi", "https://unsplash.com/@ayadighaith"), 
        new Link("Titivillus", "https://www.dafont.com/titivillus-foundry.d464"),
    };

    private TextMeshProUGUI _textMeshPro;
    private int maxVisibleChars;

    public TextMeshProUGUI TextMeshPro { get { return _textMeshPro; } set { _textMeshPro = value; } }
    public List<Link> Links { get { return links; } set { links = value; }}

    void Start(){
        TextMeshPro = GetComponent<TextMeshProUGUI>();
        TextMeshPro.SetText(textToShow.text);

        StartCoroutine(TypeWrite());
    }

    public void OnPointerClick(PointerEventData eventData){
        TextUtils.OpenLink(TextMeshPro, Links);
    }

    public System.Collections.IEnumerator TypeWrite(){
        int remaining = TextMeshPro.text.Length; 
        while (maxVisibleChars < remaining)
        {
            maxVisibleChars += 1;
            TextMeshPro.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(characterDelay);
        }

        yield break;
    }
}

[Serializable]
public class Link {
    [SerializeField]
    private string id; 
    [SerializeField]
    private string url;

    public Link(string id, string url){
        this.id = id;
        this.url = url;
    }

    public string GetId(){
        return this.id;
    }

    public string GetUrl(){
        return this.url;
    }
}

// [CustomEditor(typeof(CreditsManager))]
// public class CreditsEditor: Editor {
//     public override void OnInspectorGUI()
//     {
//         CreditsManager creditsManager = (CreditsManager) target;
//         base.OnInspectorGUI();

//         if(EditorGUI.EndChangeCheck()){
//             creditsManager.Recreate();
//         }
//     }
// } 