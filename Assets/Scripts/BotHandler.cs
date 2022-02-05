using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHandler : MonoBehaviour
{
    //Upgrade booleans
    public bool upgradeHappy;
    public bool upgradeEffi;
    public bool upgradeSec;
    public bool sabotage;

    public IndivFactory[] id = new IndivFactory[23];
    public CompanyOwners[] Company = new CompanyOwners[23];

    public string Name;

    //Timer
    public float Timer;

    void Start()
    {
        //Sets up the timer
        Timer = Time.deltaTime;

        //Sets up the starting result of the booleans
        upgradeHappy = false;
        upgradeEffi = false;
        upgradeSec = false;
        sabotage = false;
    }

    void Update()
    {
        if (Timer >= 10)
        {
            id[2].workerAmount = id[2].workerAmount + 5;
            id[2].securityLvl++;
            id[2].workerHappinessLvl++;
            id[2].workerHappiness = id[2].workerHappiness + 0.0001f;

            id[3].workerAmount = id[3].workerAmount - 1;
            id[3].efficiencyLvl++;
            id[3].securityLvl++;
            id[3].workerHappiness = id[3].workerHappiness - 0.001f;
        }
    }

}
