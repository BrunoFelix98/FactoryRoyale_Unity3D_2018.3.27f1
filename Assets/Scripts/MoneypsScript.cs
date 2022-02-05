using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneypsScript : MonoBehaviour
{
    public GameObject[] factoryUI;

    public TextMeshProUGUI MoneypsTxt;

    public int totalMoney;

    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        factoryUI = GameObject.FindGameObjectsWithTag("Factories");
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= 1)
        {
            for (int i = 0; i < factoryUI.Length; i++)
            {
                if (factoryUI[i].GetComponent<FactoryUI>().name == "FactoryWroclaw")
                {
                    totalMoney += factoryUI[i].GetComponent<FactoryUI>().id[i].moneyPerS;
                }
                /*
                if (factoryUI[i].GetComponent<FactoryUI>().name == "FactorySciniawa")
                {
                    moneyps += factoryUI[i].GetComponent<FactoryUI>().Factory[0].moneyPerS;
                }

                if (factoryUI[i].GetComponent<FactoryUI>().name == "FactoryMilicz")
                {
                    moneyps += factoryUI[i].GetComponent<FactoryUI>().Factory[0].moneyPerS;
                }
                */
            }
            Timer = 0;
        }
        Timer += Time.deltaTime;
        MoneypsTxt.SetText(totalMoney.ToString());
    }
}
