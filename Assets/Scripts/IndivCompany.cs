using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IndivCompany
{
    public int playerId;
    public int companyId;
    public int companyMoney;
    public int companyWorkerAmount;
    public int companyAmountOfFactoriesOwned;

    public IndivCompany(companiesClass company)
    {
        playerId = company.player_id;
        companyId = company.company_id;
        companyMoney = company.company_money;
        companyWorkerAmount = company.company_worker_amount;
        companyAmountOfFactoriesOwned = company.company_amount_of_factories_owned;
    }
}
