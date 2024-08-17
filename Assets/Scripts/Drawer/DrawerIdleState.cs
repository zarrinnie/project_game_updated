using System.Collections.Generic;
using System.Linq;

public class DrawerIdleState : DrawerBaseState
{
    public override void EnterState(DrawerManager drawer)
    {
        if(drawer.hiddenObjects.Count(hiddenObject => !hiddenObject.Hidden) == drawer.hiddenObjects.Length){
            drawer.finishedLevelManager.SwitchState(drawer.finishedLevelManager.shown);
        } 
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