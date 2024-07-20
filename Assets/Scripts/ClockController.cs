using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public GameObject clockText;
    public int timeLimit;
    private TextMeshProUGUI timeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = clockText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
