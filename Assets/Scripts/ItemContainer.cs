using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    public Item[] items;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < items.Length; i++){
            GameObject textbox = new GameObject(String.Format("item_{0}", i));
            textbox.transform.SetParent(this.transform);
            // TODO! Fix spawning position
            textbox.AddComponent<TextMeshProUGUI>().text = items[i].getName();
            textbox.GetComponent<RectTransform>().anchoredPosition = new Vector2(i, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
