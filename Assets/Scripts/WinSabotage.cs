using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinSabotage : MonoBehaviour
{

    public GameObject canvas;      //win
    public GameObject player;
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;

    public int factoryID;
    public int attackerID;
    public int victimID;

    public WebRequests webRequests;

    public GameObject[] enemy;

    public bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Win_Canvas");
        objective1 = GameObject.Find("objective1");
        objective2 = GameObject.Find("objective2");
        objective3 = GameObject.Find("objective3");

        factoryID = GameManager.facID;
        attackerID = GameManager.sabotagerID;
        victimID = GameManager.sabotagedID;

        hasWon = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I have collided");

        if (hasWon == false)
        {
            Debug.Log("I have not won yet " + collision.gameObject.tag);
            //if player collides with objective 1
            if (collision.gameObject.tag == "objective1")
            {
                Debug.Log("I have won on objective 1");
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(2).gameObject.SetActive(true);
                canvas.transform.GetChild(5).gameObject.SetActive(true);


                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].GetComponent<Patrol>().speed = 0;
                }

                player.GetComponent<PlayerMovement>().speed = 0;

                webRequests.postWCondSabotage(attackerID, factoryID, victimID);

                hasWon = true;
            }

            //if player collides with objective 2
            if (collision.gameObject.tag == "objective2")
            {
                Debug.Log("I have won on objective 2");
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(3).gameObject.SetActive(true);
                canvas.transform.GetChild(5).gameObject.SetActive(true);


                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].GetComponent<Patrol>().speed = 0;
                }

                player.GetComponent<PlayerMovement>().speed = 0;

                webRequests.postEffSabotage(attackerID, factoryID, victimID);

                hasWon = true;
            }

            //if player collides with objective 3
            if (collision.gameObject.tag == "objective3")
            {
                Debug.Log("I have won on objective 3");
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(4).gameObject.SetActive(true);
                canvas.transform.GetChild(5).gameObject.SetActive(true);


                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].GetComponent<Patrol>().speed = 0;
                }

                player.GetComponent<PlayerMovement>().speed = 0;

                webRequests.postWCondAndEffSabotage(attackerID, factoryID, victimID);

                hasWon = true;
            }
        }
    }
}
