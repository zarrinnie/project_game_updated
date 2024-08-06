using System.Collections;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class Item
{
    [SerializeField]
    private bool isHidden = true;

    private TextMeshProUGUI textLabel;

    public TextMeshProUGUI TextLabel
    {
        get; set;
    }

    public string Name
    {
        get
        {
            return Entity.name;
        }
        set
        {
            Entity.name = value;
        }
    }

    public bool Hidden
    {
        get
        {
            return isHidden;
        }
        set
        {
            isHidden = value;
        }
    }

    [SerializeField]
    private GameObject entity;

    public GameObject Entity
    {
        get
        {
            return entity;
        }

        set
        {
            entity = value;
        }
    }

    public override string ToString()
    {
        if (Hidden)
        {

            return string.Format("{0} item named: {1}", "Hidden", Name);
        }
        return string.Format("{0} item named: {1}", "Hidden", Name);
    }

    public IEnumerator jumpToDrawer(Vector3 textPos, ItemContainer container)
    {
        float t = 0;
        float timeToMove = 20f;
        float distance;

        // The middle position between the Item
        // and its label, rounded to 1 d.p for ease
        float middlePos = Mathf.Round(Vector2.Distance(Entity.transform.position, textPos) / 2) * 0.1f;
        while (t < 1)
        {
            Entity.transform.position = Vector2.Lerp(Entity.transform.position, textPos, t);
            t = t + Time.deltaTime / timeToMove;

            // Check the current distance between the Item 
            // and its label, rounded to 1 d.p for ease
            distance = Mathf.Round(Vector2.Distance(Entity.transform.position, textPos)) * 0.1f;

            // If we are at the middle point, toggle the 
            // explanation UI
            if (distance == middlePos) yield return new WaitWhile(() =>
            {
                bool toggled = false;
                if (!toggled)
                {
                    container.Toggle();
                    toggled = true;
                }
                return true;

            });
            else
            {

                yield return new WaitForEndOfFrame();
            }
        }
        Entity.transform.position = textPos;

        // Object reached destination
        TextLabel.SetText(string.Format("<s>{0}</s>", TextLabel.text));

        yield return null;
    }
}
