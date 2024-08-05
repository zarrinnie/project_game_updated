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
    
    public IEnumerator jumpToDrawer(){
        // TODO: Figure out how to go towards the thing
        while(Entity.transform.position != new Vector3(0.9f, 0.9f)){
            float speed = Mathf.MoveTowards(Entity.transform.position.x, 0.9f, 20f * Time.deltaTime);
            Entity.transform.position = Vector2.Lerp(Entity.transform.position, new Vector2(0.9f, 0.9f), speed);
            yield return null;
        }

        TextLabel.SetText(string.Format("<s>{0}</s>", TextLabel.text));

        yield return null;
    }
}
