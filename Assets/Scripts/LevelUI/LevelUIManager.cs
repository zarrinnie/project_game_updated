using System.Data.Common;
using UnityEngine;

public class LevelUIManager: MonoBehaviour {
    public LevelUIBaseState currentState;
    public LevelUIIdleState idle = new LevelUIIdleState();
    public LevelUIBlurState blurred = new LevelUIBlurState();

    public GameObject blurCam;

    void Start(){
        currentState = idle;
        currentState.EnterState(this);

    }

    void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(LevelUIBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }

    public void ToggleBlur(){
        Transform[] transforms = GetComponentsInChildren<Transform>();
        foreach (Transform transform in transforms)
        {
            transform.gameObject.layer = transform.gameObject.layer == 5 ? 6 : 5;
        }

        Debug.Log("Layer:" + transform.gameObject.layer);

        blurCam.SetActive(!blurCam.activeInHierarchy);
    }
}