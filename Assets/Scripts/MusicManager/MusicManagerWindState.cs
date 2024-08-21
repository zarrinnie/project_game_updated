using System;
using System.Diagnostics;
using Core;
using UnityEngine;

[Serializable]
public class MusicManagerWindState : State<MusicManager>
{
    [SerializeField]
    private AudioClip windTheme;
    public override void EnterState(MusicManager stateHolder)
    {
        stateHolder.SetAlpha(0);

        stateHolder.audioClip.clip = windTheme;
        stateHolder.audioClip.Play();
    }

    public override void UpdateState(MusicManager stateHolder)
    {
        if(!stateHolder.audioClip.isPlaying){
            stateHolder.SwitchState(stateHolder.playingMainMusic);
        }
    }
}