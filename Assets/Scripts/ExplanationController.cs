using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationController : MonoBehaviour
{
    public GameObject levelUiContainer;
    public GameObject blurCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ToggleBlurLayer(int UiLayer, int blurLayer)
    {
        Transform[] transforms = levelUiContainer.GetComponentsInChildren<Transform>();
        foreach (Transform transform in transforms)
        {
            transform.gameObject.layer = transform.gameObject.layer == UiLayer ? blurLayer : UiLayer;
        }

        blurCam.SetActive(!blurCam.activeInHierarchy);
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
