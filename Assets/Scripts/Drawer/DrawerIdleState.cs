using UnityEngine;
using TMPro;

public class DrawerIdleState : DrawerBaseState
{
    public override void EnterState(DrawerManager drawer)
    {
    }

    public override void UpdateState(DrawerManager drawer)
    {
        for(int i = 0; i < drawer.hiddenObjects.Length; i++){
            if(!drawer.hiddenObjects[i].Hidden){
                drawer.meshes[i].SetText(string.Format("<s>{0}</s>", drawer.meshes[i].text));
            }
        }
    }
}