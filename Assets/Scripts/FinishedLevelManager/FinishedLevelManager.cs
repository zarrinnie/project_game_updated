using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevelManager : MonoBehaviour
{
    public State<FinishedLevelManager> current;
    public FinishedLevelIdleState idle = new FinishedLevelIdleState();
    public FinishedLevelShowState shown = new FinishedLevelShowState();
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        current = idle;
        current.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(State<FinishedLevelManager> state){
        current = state;
        current.EnterState(this);
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("Main_menu");
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
