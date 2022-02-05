using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollManager : MonoBehaviour
{
    // Start is called before the first frame update
    public IndivPlayer[] Pid = new IndivPlayer[1];
    public IndivCompany[] Cid = new IndivCompany[23];
    public IndivFactory[] id = new IndivFactory[23];
    public WebRequests webRequests;
    public ScrollPick scroll1;
    public ScrollPick scroll2;
    public ScrollPick scroll3;
    public ScrollPick scroll4;
    public TextMeshProUGUI moneyTxt;
    public string amountOfMoney;
    public TextMeshProUGUI result;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        int conn = PlayerPrefs.GetInt("playerconn");

        if (conn == 0)
        {
            webRequests.getPlayers2(this);
        }
        else
        {
            Debug.Log(conn);
        }
    }

    public void Update()
    {
        webRequests.getCompany2();
        webRequests.getFactory2();
        moneyTxt.SetText(Cid[0].companyMoney + " €");
    }

    public void getEffLvl()
    {
        if (Cid[0].companyMoney >= scroll1.Price)
        {
            webRequests.getEffLevel(scroll1.SelectedFac, Pid[0].playerCode, scroll1.Price);
            result.SetText("The efficiency level of the factory is: " + id[scroll1.SelectedFac].efficiencyLvl);
            webRequests.postMoney(Pid[0].playerCode, Cid[0].companyMoney);
            webRequests.getMoney(Pid[0].playerCode);
        }
        else
        {
            result.SetText("You dont have enough money!");
        }
    }

    public void getSecLvl()
    {
        if (Cid[0].companyMoney >= scroll2.Price)
        {
            webRequests.getSecLevel(scroll2.SelectedFac, Pid[0].playerCode, scroll2.Price);
            result.SetText("The security level of the factory is: " + id[scroll2.SelectedFac].securityLvl);
            webRequests.postMoney(Pid[0].playerCode, Cid[0].companyMoney);
            webRequests.getMoney(Pid[0].playerCode);
        }
        else
        {
            result.SetText("You dont have enough money!");
        }
    }

    public void getWcondLvl()
    {
        if (Cid[0].companyMoney >= scroll3.Price)
        {
            webRequests.getWCondLevel(scroll3.SelectedFac, Pid[0].playerCode, scroll3.Price);
            result.SetText("The worker conditions level of the factory is: " + id[scroll3.SelectedFac].workerHappinessLvl);
            webRequests.postMoney(Pid[0].playerCode, Cid[0].companyMoney);
            webRequests.getMoney(Pid[0].playerCode);
        }
        else
        {
            result.SetText("You dont have enough money!");
        }
    }
}
