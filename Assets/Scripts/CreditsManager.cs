using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsManager : MonoBehaviour, IPointerClickHandler {
    [SerializeField]
    private TextAsset textToShow;
    
    [SerializeField]
    private float characterDelay = 0.01f;
    [SerializeField]
    private List<Link> linkids;
    private TextMeshProUGUI textMeshPro;
    private int maxVisibleChars;
    void Start(){
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText(textToShow.text);

        StartCoroutine(TypeWrite());
    }

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("CLICKED");
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, Camera.main);

        string linkId = textMeshPro.textInfo.linkInfo[linkIndex].GetLinkID();

        string matchedUrl = linkids.First(link => link.GetId().Equals(linkId)).GetUrl();

        if(matchedUrl != null){
            Application.OpenURL(matchedUrl);
        }
    }

    public System.Collections.IEnumerator TypeWrite(){
        int remaining = textMeshPro.text.Length; 
        while (maxVisibleChars < remaining)
        {
            maxVisibleChars += 1;
            textMeshPro.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(characterDelay);
        }

        yield break;
    }

    // For editor reload
    // public void Recreate(){
    //     textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();
    //     textMeshPro.SetText(textToShow.text);
    // }
}

[Serializable]
public class Link {
    [SerializeField]
    private string id; 
    [SerializeField]
    private string url;

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