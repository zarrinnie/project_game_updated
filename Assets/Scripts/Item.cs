using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
}
