using NUnit.Framework;
using UnityEngine.SceneManagement;

public class GameTest {
    [OneTimeSetUp]
    public void SetupStartingScene(){
        SceneManager.LoadScene("Title_screen");
        SceneManager.LoadScene("Main_menu");
    }
}