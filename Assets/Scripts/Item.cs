using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    [SerializeField]
    private String name;
    [SerializeField]
    private bool isHidden;
    [SerializeField]
    private GameObject itemGameObj;

    Item(String name)
    {
        this.name = name;
    }

    public String getName(){
        return this.name;
    }

    public bool getHiddenStatus(){
        return this.isHidden;
    }

    public GameObject getReferencedItem(){
        return this.itemGameObj;
    }

    public override String ToString()
    {
        if (isHidden)
        {

            return String.Format("{0} item named: {1}", "Hidden", this.name);
        }
        return String.Format("{0} item named: {1}", "Hidden", this.name);

    }
}
