using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject player;
    public GameObject canvas;

    public WebRequests webRequests;

    //values recieved form the FactoryUI
    public int factoryID;
    public int attackerID;
    public int victimID;

    private Timer timer;

    void Start()
    {
        //gives the variables values
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Lose_Canvas");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        timer = FindObjectOfType<Timer>();
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //checks if the player collides with the enemy
        if (collisionInfo.gameObject.tag == "Player")
        {
            

            canvas.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(2).gameObject.SetActive(true);
            canvas.transform.GetChild(3).gameObject.SetActive(true);

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].GetComponent<Patrol>().speed = 0;
            }

            player.GetComponent<PlayerMovement>().speed = 0;

            timer.currentTime = 0;
        }
    }
}