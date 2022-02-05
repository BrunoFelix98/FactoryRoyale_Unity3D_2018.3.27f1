using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAI : MonoBehaviour
{
    private int currentTask;

    public int money;
    public int secLvl;
    public int effLvl;
    public int wCLvl;
    public int chance;
    public int workerAmount;

    // Start is called before the first frame update
    void Start()
    {
        currentTask = 1;
        workerAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTask == 1)
        {
            if (money >= 1000)
            {
                secLvl++;
                money = money - 1000;
            }
        }

        if (currentTask == 2)
        {
            chance = Random.Range(0, 100);

            if (chance > 0 && chance < 20)
            {
                //sabotage failed

                money = money - 1000;
                workerAmount = workerAmount - 10;
            }
            else
            {
                //sabotage succeded
                money = money + 10000;
            }
        }
    }
}
