using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    // Scene to switch to
    public string scene;
    public Image imageToZoom;
    private Animator imageAnimator;

    // Start is called before the first frame update
    void Start()
    {
        imageAnimator = imageToZoom.GetComponent<Animator>();
    }

    // Called when pressing on quit 
    public void quit(){
        // We can't quit in the editor
        Debug.Log("QUIT");
        Application.Quit();
    }

    // Called when pressing the start button
    public void switchMenu()
    {
        StartCoroutine(transition());
    }

    // Coroutine to smooth transitions while loading levels
    private IEnumerator transition()
    {
        float time = 0;

        // Start transition
        imageAnimator.SetBool("nextLevel", true);

        // Get the length of the animation
        float delay = imageAnimator.GetCurrentAnimatorStateInfo(0).length;

        // The zoom transition is still playing
        while (time < delay)
        {
            time += Time.deltaTime;
            yield return null;
        }

        // Smooth load the scene
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
