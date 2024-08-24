using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Core;
using UnityEngine;

[Serializable]
public class DrawerIdleState : State<DrawerManager>
{
    [SerializeField]
    private GameObject particlesPrefab;
    private Vector3 mousePos { get; set; }
    private List<GameObject> instantiatedParticleObjects = new List<GameObject>();
    public override void EnterState(DrawerManager drawer)
    {
        if (drawer.hiddenObjects.Count(hiddenObject => !hiddenObject.Hidden) == drawer.hiddenObjects.Length)
        {
            drawer.finishedLevelManager.SwitchState(drawer.finishedLevelManager.shown);
        }
    }

    public override void UpdateState(DrawerManager drawer)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instantiatedParticles = GameObject.Instantiate(particlesPrefab, mousePos, Quaternion.identity);
            instantiatedParticleObjects.Add(instantiatedParticles);
            ParticleSystem instantiatedParticleSystem = instantiatedParticles.GetComponent<ParticleSystem>();
            instantiatedParticleSystem.Play();
        }

        for (int i = 0; i < drawer.hiddenObjects.Length; i++)
        {
            if (!drawer.hiddenObjects[i].Hidden)
            {
                drawer.meshes[i].SetText(string.Format("<s>{0}</s>", drawer.meshes[i].text));
            }
        }

        if (instantiatedParticleObjects.Count > 0)
        {
            // Cleans up particle systems that are done playing
            instantiatedParticleObjects.Where(particleObject => !particleObject.GetComponent<ParticleSystem>().isPlaying)
                .ToList()
                .ForEach(particleObject =>
                {
                    GameObject.Destroy(particleObject);
                    instantiatedParticleObjects.Remove(particleObject);

                });
        }
    }
}