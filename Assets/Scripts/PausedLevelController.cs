using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedLevelController : MonoBehaviour
{
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePaused();
        }
    }

    public void TogglePaused(){
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale != 0 ? 0 : 1;
    }
}
