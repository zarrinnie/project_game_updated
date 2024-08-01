using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public GameObject hintButton;
    public GameObject itemDrawer;
    private ItemContainer itemContainer;

    public int availableHints = 2;
    private int usedHints = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        itemContainer = itemDrawer.GetComponent<ItemContainer>();
    }

    public void getHint()
    {
        if (usedHints < availableHints)
        {
            int randIndex = Random.Range(0, itemContainer.items.Length);
            hintButton.GetComponentInChildren<TextMeshProUGUI>().SetText(itemContainer.items[randIndex].Name);
            usedHints++;

            if(usedHints == availableHints){
                hintButton.GetComponent<Button>().interactable = false;

            }

        } 
    }
}
