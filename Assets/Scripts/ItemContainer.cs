using System;
using TMPro;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Item[] items;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < items.Length; i++){
            GameObject textbox = new GameObject(String.Format("item_{0}", i));
            textbox.transform.SetParent(this.transform);
            textbox.AddComponent<TextMeshProUGUI>().text = items[i].getName();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
