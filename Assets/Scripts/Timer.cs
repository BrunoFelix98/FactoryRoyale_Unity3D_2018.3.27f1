using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 40f;

    public bool countingdown;

    public GameObject canvas;
    public GameObject player;

    private WinSabotage winBool;

    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = startingTime;

        countingdown = true;

        canvas = GameObject.Find("Lose_Canvas");
        player = GameObject.Find("Player");
        countdownText = FindObjectOfType<Text>();

        winBool = FindObjectOfType<WinSabotage>();
    }

    private void Update()
    {
        if (winBool.hasWon == false)
        {
            if (countingdown == true)
            {
                currentTime -= 1 * Time.deltaTime;
            }
            countdownText.text = currentTime.ToString("0");

            if (currentTime < 5)
            {
                countdownText.color = Color.red;
            }

            if (currentTime <= 0)
            {
                countingdown = false;

                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(2).gameObject.SetActive(true);
                canvas.transform.GetChild(3).gameObject.SetActive(true);

                player.GetComponent<PlayerMovement>().speed = 0;
            }
        }
    }
}
