using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    // Textual Utils
    public class TextUtils
    {
        // Checks if 
        public static void OpenLink(TextMeshProUGUI textMeshPro, List<Link> links)
        {
            Debug.Log("CLICKED");
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, Camera.main);

            string linkId = textMeshPro.textInfo.linkInfo[linkIndex].GetLinkID();

            string matchedUrl = links.First(link => link.GetId().Equals(linkId)).GetUrl();

            if (matchedUrl != null)
            {
                Application.OpenURL(matchedUrl);
            }
        }
    }

    public interface ICommonTypewritable {
        public TextMeshProUGUI TextMeshPro { get; set; }
        public List<Link> Links { get; set; }
    }
    
    public interface ITypewritable : IPointerClickHandler, ICommonTypewritable
    {
        public IEnumerator TypeWrite();
    }

    public interface ITypewritable<T> : IPointerClickHandler, ICommonTypewritable
    {
        public IEnumerator TypeWrite(T state);
    }
}