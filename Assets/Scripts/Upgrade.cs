using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    //Game objects & scripts
    public GameObject Popup;
    private FactoryUI Moneys;
    public FactoryUI factoryUIScript;
    public FactoryUI happylvl1;
    public FactoryUI efflvl1;
    public FactoryUI seclvl1;
    public FactoryUI happylvl2;
    public FactoryUI efflvl2;
    public FactoryUI seclvl2;
    public FactoryUI happylvl3;
    public FactoryUI efflvl3;
    public FactoryUI seclvl3;
    public FactoryUI happylvl4;
    public FactoryUI efflvl4;
    public FactoryUI seclvl4;
    public FactoryUI happylvl5;
    public FactoryUI efflvl5;
    public FactoryUI seclvl5;
    [SerializeField] GameObject upgradeScreen;

    //Ints
    public int factorySelected;

    //Buttons
    public Button UpgradeHappy1;
    public Button UpgradeHappy2;
    public Button UpgradeHappy3;
    public Button UpgradeHappy4;
    public Button UpgradeHappy5;
    public Button UpgradeSecurity1;
    public Button UpgradeSecurity2;
    public Button UpgradeSecurity3;
    public Button UpgradeSecurity4;
    public Button UpgradeSecurity5;
    public Button UpgradeEfficiency1;
    public Button UpgradeEfficiency2;
    public Button UpgradeEfficiency3;
    public Button UpgradeEfficiency4;
    public Button UpgradeEfficiency5;

    private void Awake()
    { 
        //Gets the money class
        Moneys = FindObjectOfType<FactoryUI>();
        factoryUIScript = FindObjectOfType<FactoryUI>();
        upgradeScreen = GameObject.Find("UpgradesPanel");
    }

    public void HappinessUpgrade()
    {
        //Checks if the player has enough money to upgrade the different levels of the factory
        if (Moneys.Cid[1].companyMoney >= 200)
        {
            //For the worker conditions upgrades

            Moneys.Cid[1].companyMoney = Moneys.Cid[1].companyMoney - 200;


        }
        else
        {
            //Create a popup saying you dont have enough money to upgrade
            Popup.SetActive(true);
            upgradeScreen.SetActive(false);
            Debug.Log("You Dont Have Money");
        }
    }

    public void SecurityUpgrade()
    {
        if (Moneys.Cid[1].companyMoney >= 500)
        {
            //For the security upgrades

            Moneys.Cid[1].companyMoney = Moneys.Cid[1].companyMoney - 500;
        }
        else
        {
            //Create a popup saying you dont have enough money to upgrade
            Popup.SetActive(true);
            upgradeScreen.SetActive(false);
            Debug.Log("You Dont Have Money");
        }
    }

    public void EfficiencyUpgrade()
    {
        if (Moneys.Cid[1].companyMoney >= 300)
        {
            //For the efficiency upgrades

            Moneys.Cid[1].companyMoney = Moneys.Cid[1].companyMoney - 500;
        }
        else
        {
            //Create a popup saying you dont have enough money to upgrade
            Popup.SetActive(true);
            upgradeScreen.SetActive(false);
            Debug.Log("You Dont Have Money");
        }
    }  
}
