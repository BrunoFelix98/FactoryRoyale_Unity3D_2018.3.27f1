using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pause : MonoBehaviour
{
    public GameObject pausePanel;
    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            pauseFunc();
        }
    }

    public void pauseFunc()
    {
        Time.timeScale = 0;
    }
}
