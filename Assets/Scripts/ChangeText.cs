using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public string companyName;
    public GameObject inputField;
    public WebRequests webRequests;
    public TextMeshProUGUI playerCode;
    public IndivPlayer[] Pid = new IndivPlayer[1];

    public void Start()
    {
        PlayerPrefs.DeleteAll();

        int conn = PlayerPrefs.GetInt("playerconn");

        if (conn == 0)
        {
            webRequests.getPlayers3();
        }
        else
        {
            Debug.Log(conn);
        }
    }

    public void newName()
    {
        companyName = inputField.GetComponent<TextMeshProUGUI>().text;

    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(companyName);
        }

        playerCode.SetText("Your code is: " + Pid[0].playerCode.ToString() + ". You will use it in the app.");
    }
}
