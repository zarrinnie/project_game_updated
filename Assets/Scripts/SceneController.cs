using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    public GameObject[] uiContainers;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Called when pressing on quit 
    public void Quit(){
        Application.Quit();
    }

    // Called when pressing the start button
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Title_screen");
    }

    public void ShowThing(int index){
        foreach(GameObject ui in uiContainers){
            ui.SetActive(false);
        }

        uiContainers[index].SetActive(true);
    }

    // Coroutine to smooth transitions while loading levels
    // private IEnumerator transition()
    // {
    //     float time = 0;

    //     // Start transition
    //     imageAnimator.SetBool("nextLevel", true);

    //     // Get the length of the animation
    //     float delay = imageAnimator.GetCurrentAnimatorStateInfo(0).length;

    //     // The zoom transition is still playing
    //     while (time < delay)
    //     {
    //         time += Time.deltaTime;
    //         yield return null;
    //     }

    //     // Smooth load the scene
    //     yield return new WaitForSeconds(1);
    //     SceneManager.LoadScene(scene);
    // }
}
