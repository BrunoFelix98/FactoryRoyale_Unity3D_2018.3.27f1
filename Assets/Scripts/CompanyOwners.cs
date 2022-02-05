using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyOwners
{
    public int id;
    public int ownerId;
    public int money;
    public string name;

    public CompanyOwners(int Id, int OwnerId, int Money, string Name)
    {
        id = Id;
        ownerId = OwnerId;
        money = Money;
        name = Name; //String
    }
}
