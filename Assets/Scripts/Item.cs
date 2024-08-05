using System.Collections;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class Item
{
    [SerializeField]
    private bool isHidden;

    private TextMeshProUGUI textLabel;

    public TextMeshProUGUI TextLabel {
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

    public GameObject Entity {
        get {
            return entity;
        } 

        set {
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
    
    public IEnumerator jumpToDrawer(Vector3 startPos, Vector3 textPos, float t){
        float speed = 1.5f;
        // TODO: Figure out how to go towards the thing
        while(t < 1){
            t += Time.deltaTime / speed;

            if(t > 1) t = 1;

            Entity.transform.position = Vector3.Lerp(startPos, textPos, t);
            yield return null;
        }

        TextLabel.SetText(string.Format("<s>{0}</s>", TextLabel.text));

        yield return null;
    }
}
