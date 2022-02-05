using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IndivPlayer
{
    public int playerCode;
    public string playerCompanyName;

    public IndivPlayer(int pCode, string pCompany)
    {
        playerCode = pCode;
        playerCompanyName = pCompany;
    }
}
