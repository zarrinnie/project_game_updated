using UnityEngine.SceneManagement;

public class FinishedLevelShowState : FinishedLevelBaseState
{
    public override void EnterState(FinishedLevelManager finishedLevelManager)
    {
        finishedLevelManager.canvas.enabled = true;
    }

    public override void UpdateState(FinishedLevelManager finishedLevelManager)
    {
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("Main_menu");
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}