using NUnit.Framework;
using UnityEngine.SceneManagement;

public class LevelTest {

    [OneTimeSetUp]
    public void LoadTestScene(){
        SceneManager.LoadScene("Level_UI");
    }
}