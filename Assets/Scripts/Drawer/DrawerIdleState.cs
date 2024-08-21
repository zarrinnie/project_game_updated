using System;
using System.Linq;
using Core;
using UnityEngine;

[Serializable]
public class DrawerIdleState : State<DrawerManager>
{
    [SerializeField]
    private GameObject particlesPrefab;
    private Vector3 mousePos { get; set; }
    public override void EnterState(DrawerManager drawer)
    {
        if(drawer.hiddenObjects.Count(hiddenObject => !hiddenObject.Hidden) == drawer.hiddenObjects.Length){
            drawer.finishedLevelManager.SwitchState(drawer.finishedLevelManager.shown);
        } 
    }

    public override void UpdateState(DrawerManager drawer)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            GameObject instantiatedParticles = GameObject.Instantiate(particlesPrefab, mousePos, Quaternion.identity);
            ParticleSystem instantiatedParticleSystem = instantiatedParticles.GetComponent<ParticleSystem>();
            instantiatedParticleSystem.Play();
        }

        for(int i = 0; i < drawer.hiddenObjects.Length; i++){
            if(!drawer.hiddenObjects[i].Hidden){
                drawer.meshes[i].SetText(string.Format("<s>{0}</s>", drawer.meshes[i].text));
            }
        }

    }
}