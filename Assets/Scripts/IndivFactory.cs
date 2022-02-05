using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IndivFactory
{
    public int id;
    public string factoryName;
    public int ownerId;
    public int securityLvl;
    public int workerHappinessLvl;
    public int efficiencyLvl;
    public int moneyPerS;
    public int workerAmount;
    public int houseAmount;
    public int buyPrice;
    public float workerHappiness; //percent

    public IndivFactory(factoriesClass factory)
    {
        id = factory.factory_id;
        factoryName = factory.factory_name;
        ownerId = factory.factory_owner_id;
        securityLvl = factory.factory_security_level;
        workerHappinessLvl = factory.factory_worker_conditions_level;
        efficiencyLvl = factory.factory_efficiency_level;
        moneyPerS = factory.factory_money_per_second;
        workerAmount = factory.factory_worker_amount;
        houseAmount = factory.factory_house_amount;
        workerHappiness = factory.factory_worker_happiness; //percent 
        buyPrice = factory.factory_buy_price;
    }
}