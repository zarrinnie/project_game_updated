using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPanelManager : MonoBehaviour
{
    public DrawerManager drawer;
    public DrawerManager Drawer
    {
        get
        {
            return drawer;

        }
        private set
        {
            drawer = value;
        }
    }

    public GameObject garudaBird;
    public Button hintButton;
    public AudioSource audioSource;
    public HiddenObjectHighlighted hiddenObjectHighlighted = new HiddenObjectHighlighted();
    public int availableHints;
    public int randIndex;

    void Start(){

    }

    void Update(){
    }

    public void GetHint()
    {
        if (availableHints != 0)
        {
            availableHints -= 1;
            randIndex = Random.Range(0, drawer.hiddenObjects.Length);

            if(availableHints == 0){
                hintButton.interactable = false;
            }

            StartCoroutine(showHint(drawer.hiddenObjects[randIndex]));
        }
    }

    public IEnumerator showHint(HiddenObjectManager itemPost)
    {
        hintButton.interactable = false;
        float t = 0;
        float timeToMove = 3f;
        audioSource.Play();
        yield return new WaitForSeconds(1);

        while (t < 1)
        {
            garudaBird.transform.position = Vector2.Lerp(garudaBird.transform.position, itemPost.transform.position, t);
            t = t + Time.deltaTime / timeToMove;
            yield return new WaitForEndOfFrame();
        }

        garudaBird.transform.position = itemPost.transform.position;
        itemPost.highlighted = hiddenObjectHighlighted;
        itemPost.SwitchState(hiddenObjectHighlighted);
        // yield return new WaitForSeconds(1);

        t = 0;
        while (t < 1)
        {
            garudaBird.transform.position = Vector2.Lerp(garudaBird.transform.position, gameObject.transform.position, t);
            t = t + Time.deltaTime / timeToMove;
            yield return new WaitForEndOfFrame();
        }

        garudaBird.transform.position = gameObject.transform.position;

        hintButton.interactable = true;
        yield break;

    }
}
