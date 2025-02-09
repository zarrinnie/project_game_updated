using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Core;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class MusicManager : MonoBehaviour
{
    public State<MusicManager> current;
    public MusicManagerWindState playingWind = new MusicManagerWindState();
    public MusicManagerMainMusic playingMainMusic = new MusicManagerMainMusic();

    public Canvas mainTitleCanvas;
    public List<string> mainThemeScenes;
    [NonSerialized]
    public AudioSource audioClip;
    public List<TextMeshProUGUI> textMeshes;
    public List<GameObject> buttons;
    [SerializeField]
    [Range(0.16f, 1f)]
    private float volume = 0.16f;

    void Awake()
    {
        // Preserve music across title screens
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioClip = gameObject.AddComponent<AudioSource>();

        current = playingWind;
        current.EnterState(this);
    }

    void FixedUpdate()
    {
        audioClip.volume = volume; 

        current.UpdateState(this);
    }

    public void SwitchState(State<MusicManager> state)
    {
        current = state;
        state.EnterState(this);
    }

    public void SetAlpha(float alpha)
    {
        if (textMeshes.Any(textMesh => textMesh == null) && buttons.Any(button => button == null)){
            return;
        } else {
            textMeshes.ForEach(textMesh =>
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            });

            buttons.ForEach(button =>
            {
                Image currentImage = button.GetComponent<Image>();
                currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, alpha);
            });
        }
    }
}
