using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class MusicManagerMainMusic : State<MusicManager>
{
    [SerializeField]
    private AudioClip mainTheme;
    [SerializeField]
    private float textAnimationSpeed;
    private float alpha;
    public override void EnterState(MusicManager stateHolder)
    {
        stateHolder.audioClip.clip = mainTheme;
        stateHolder.audioClip.loop = true;
        stateHolder.audioClip.Play();
    }

    public override void UpdateState(MusicManager stateHolder)
    {
        alpha = alpha > 1.0f ? 1 : alpha + Time.deltaTime / textAnimationSpeed;
        stateHolder.SetAlpha(alpha);
    }
}