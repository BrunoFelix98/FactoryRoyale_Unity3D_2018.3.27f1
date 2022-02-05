using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private GameObject canvas;
    public Button Resume;
    public Button Quit;

    public bool paused;
    public bool buttonisclicked;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        buttonisclicked = false;

        Button Rbtn = Resume.GetComponent<Button>();
        Rbtn.onClick.AddListener(TaskOnClick);

        Button Qbtn = Quit.GetComponent<Button>();
        Qbtn.onClick.AddListener(BackToGame);

        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(2).gameObject.SetActive(true);
            canvas.transform.GetChild(3).gameObject.SetActive(true);

            paused = true;
        }
    }

    public void TaskOnClick()
    {
        if (paused == true)
        {
            Debug.Log("You have clicked the button!");
            //set our bool to true
            buttonisclicked = true;
        }
    }

    public void BackToGame()
    {
        if (paused == true)
        {
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void OnGUI()
    {
        if (buttonisclicked == true)
        {
            Debug.Log("Hi");
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);
            paused = false;
            buttonisclicked = false;
        }
    }
}
