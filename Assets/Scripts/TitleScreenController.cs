using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Called when pressing on quit 
    public void Quit()
    {
        Application.Quit();
    }

    // Called when pressing the start button
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }

}
