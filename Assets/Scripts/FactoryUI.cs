using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Windows;

public class FactoryUI : MonoBehaviour
{
    //Populates the companies and factories in the game
    public IndivFactory[] id = new IndivFactory[23];
    public IndivCompany[] Cid = new IndivCompany[23];
    public IndivPlayer[] Pid = new IndivPlayer[1];
    public Transform[] FacPos;

    //Web requests handler script
    public WebRequests webRequests;

    //Game objects & scripts
    //public Death death;
    //values to send to Death script
    public int facID;
    public int sabotagerID;
    public int sabotagedID;

    private SpriteRenderer rend;

    //Gets the PreFab
    [SerializeField] GameObject HousesPrefab;
    public GameObject upgradeScreen;
    public GameObject Popup;
    public GameObject upgbGameObj;
    public GameObject factory;
    public Image WorkerHappinessImage;
    public GameObject factoryPanel;
    public Upgrade upgradePanel;
    public GameObject SabotageButton;
    public GameObject UpgradeButton;
    public GameObject BuyButton;
    private UpgradeBtn upgbScript;
    public GameObject CNameGameObject;
    public ScrollManager scrollManager;

    //Text meshes
    public TextMeshProUGUI Happiness;
    public TextMeshProUGUI MoneyPerS;
    public TextMeshProUGUI SecurityLevel;
    public TextMeshProUGUI EfficiencyLevel;
    public TextMeshProUGUI WorkerAmount;
    public TextMeshProUGUI MoneyTxt;
    public TextMeshProUGUI currLvl;
    public TextMeshProUGUI futureLvl;
    public TextMeshProUGUI effects;
    public TextMeshProUGUI cost;

    //Booleans
    public bool sabotaged;
    //public bool HappinessUpgraded;
    //public bool SecurityLevelUpgraded;
    //public bool EfficiencyLevelUpgraded;
    public bool HappinessSelected;
    public bool SecuritySelected;
    public bool EfficiencySelected;

    //Sprites
    public Sprite Angry;
    public Sprite slightlyAngry;
    public Sprite neutralHappiness;
    public Sprite slightlyHappy;
    public Sprite Happy;

    //Ints
    public int picked;
    public int factorySelected;
    public int housesInstanciated;
    public int HappLvl;
    public int SecLvl;
    public int EffLvl;
    public int UpgradeCost;

    //ints for the bots upgrading/sabotaging/buying factories
    public int randomFac1;
    public int randomFac2;
    public int randomFac3;
    public int randomComp1;
    public int randomComp2;
    public int randomComp3;

    //floats
    public float Timer;
    public float Timer2;
    public float Timer3;
    public float Timer4;
    public float UpgTimer;

    //Strings
    private string unknown = "???";

    //Size of the Spawning Area for the houses
    public Vector2 size;
    public Vector2 NoPos;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        int conn = PlayerPrefs.GetInt("playerconn");

        if (conn == 0)
        {
            webRequests.getPlayers();
        }
        else
        {
            Debug.Log(conn);
        }

        CNameGameObject = GameObject.Find("Scrolls");
        scrollManager = CNameGameObject.GetComponent<ScrollManager>();

        HappLvl = id[factorySelected].workerHappinessLvl;
        SecLvl = id[factorySelected].securityLvl;
        EffLvl = id[factorySelected].efficiencyLvl;

        //Sets bools to false
        sabotaged = false;
        HappinessSelected = false;
        SecuritySelected = false;
        EfficiencySelected = false;

        //Gets the upgrade button class
        upgbScript = upgbGameObj.GetComponent<UpgradeBtn>();

        //Gets the factory tagged objects
        factory = GameObject.FindGameObjectWithTag("Factories");

        //Gets the worker amount
        WorkerAmount.SetText(id[factorySelected].workerAmount.ToString());

        //Get the house prefab
        HousesPrefab = GameObject.FindGameObjectWithTag("HomePref");

    }

    // Update is called once per frame
    void Update()
    {
        //Sets the timers;
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
        Timer3 += Time.deltaTime;
        UpgTimer += Time.deltaTime / 100;

        sabotagerID = Cid[0].companyId;
        facID = id[factorySelected].id;
        sabotagedID = id[factorySelected].ownerId;

        //Changes the money of each company every 5 seconds;
        if (Timer >= 5)
        {
            for (int i = 0; i < Cid.Length; i++)
            {
                if (Cid[i].companyAmountOfFactoriesOwned >= 1)
                {
                    if (Cid[i].companyId == id[i].ownerId)
                    {
                        Cid[i].companyMoney += id[i].moneyPerS;
                        webRequests.postMoney(Cid[i].playerId, Cid[i].companyMoney);
                    }
                    else
                    {
                        Cid[i].companyMoney = 0;
                        webRequests.postMoney(Cid[i].playerId, Cid[i].companyMoney);
                        Debug.Log("This company has no factories" + i + 1);
                    }
                }
                else
                {
                    Debug.Log("This company has no factories" + i + 1);
                }
                //Functions to populate the companies and the factories in the game
                webRequests.getFactory();
                webRequests.getCompany();
                Timer = 0;
            }
        }

        //bots doing upgrades
        if (Timer2 >= 90)
        {
            randomFac1 = Random.Range(2, 23);
            randomFac2 = Random.Range(2, 23);
            randomFac3 = Random.Range(2, 23);

            randomComp1 = id[randomFac1].ownerId;
            randomComp2 = id[randomFac2].ownerId;
            randomComp3 = id[randomFac3].ownerId;

            if (randomFac1 == randomFac2)
            {
                randomFac1 = Random.Range(2, 23);
            }

            if (randomFac2 == randomFac3)
            {
                randomFac2 = Random.Range(2, 23);
            }

            if (randomFac1 == randomFac3)
            {
                randomFac1 = Random.Range(2, 23);
            }

            Timer2 = 0;

            webRequests.postBEffUpgrade();
            webRequests.postBSecUpgrade();
            webRequests.postBWCondUpgrade();
        }

        //bots sabotaging every 120 seconds, player can be a target of sabotage but will never be a sabotager
        if (Timer3 >= 120)
        {
            int sabotagerCompID = Random.Range(2, 23);
            int sabotagedFacID = Random.Range(1, 23);
            int sabotagedCompID = id[sabotagedFacID].ownerId;

            if (sabotagerCompID == sabotagedCompID)
            {
                Timer3 = 0;
            }
            else
            {
                int sabotageType = Random.Range(1, 3);

                if (sabotageType == 1)
                {
                    webRequests.postEffSabotage(sabotagerCompID, sabotagedFacID, sabotagedCompID);
                    Timer3 = 0;
                }
                else if (sabotageType == 2)
                {
                    webRequests.postWCondSabotage(sabotagerCompID, sabotagedFacID, sabotagedCompID);
                    Timer3 = 0;
                }
                else if (sabotageType == 3)
                {
                    webRequests.postWCondAndEffSabotage(sabotagerCompID, sabotagedFacID, sabotagedCompID);
                    Timer3 = 0;
                }
            }
        }

        //a random bot trying to buy a factory every 5 minutes
        if (Timer4 >= 540)
        {
            //gets a fac to be be bought
            randomFac1 = Random.Range(2, 23);

            //gets company that is buying
            randomComp1 = Random.Range(2, 23);

            if (id[randomFac1].ownerId == randomComp1)
            {
                randomFac1 = Random.Range(2, 23);
            }
            else
            {
                webRequests.postBBuyFactory();
            }

            Timer4 = 0;
        }


        MoneyTxt.SetText(Cid[0].companyMoney.ToString());

        if (id[factorySelected].ownerId == 1)
        {
            WorkerAmount.SetText(Cid[factorySelected].companyWorkerAmount.ToString());
        }
        else if (id[factorySelected].ownerId != 1)
        {
            WorkerAmount.SetText(unknown);
        }
        else
        {
            WorkerAmount.SetText(Cid[1].companyWorkerAmount.ToString());
        }
        
        if (housesInstanciated < id[factorySelected].houseAmount)
        {
            SpawnHouses();
            housesInstanciated++;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            id[factorySelected].moneyPerS = id[factorySelected].moneyPerS + (5 * 100);
        }

        //Sk abotaging downgrade
        if (sabotaged == true)
        {
            id[factorySelected].workerHappiness -= 0.05f;
            id[factorySelected].efficiencyLvl--;
            id[factorySelected].workerAmount -= 5;
        }

        //Adds one house if worker amount is over 10
        id[factorySelected].houseAmount = id[factorySelected].workerAmount / 10;


        //Esc clears the UI
        if (factoryPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            factoryPanel.SetActive(false);
        }

        //Esc clears the UI
        if (upgradeScreen.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            upgradeScreen.SetActive(false);
        }

        if (id[factorySelected].workerHappiness >= 0 && id[factorySelected].workerHappiness <= 20)
        {
            if (id[factorySelected].workerHappiness <= 0)
            {
                id[factorySelected].workerHappiness = 0;
            }
            WorkerHappinessImage.sprite = Angry;
        }
        else if (id[factorySelected].workerHappiness >= 20 && id[factorySelected].workerHappiness <= 40)
        {
            WorkerHappinessImage.sprite = slightlyAngry;
        }
        else if (id[factorySelected].workerHappiness >= 40 && id[factorySelected].workerHappiness <= 60)
        {
            WorkerHappinessImage.sprite = neutralHappiness;
        }
        else if (id[factorySelected].workerHappiness >= 60 && id[factorySelected].workerHappiness <= 80)
        {
            WorkerHappinessImage.sprite = slightlyHappy;
        }
        else if (id[factorySelected].workerHappiness >= 80 && id[factorySelected].workerHappiness <= 100)
        {
            WorkerHappinessImage.sprite = Happy;
        }
    }

    //Detect if a click occurs
    public void OpenPanel()
    {
        Debug.Log("hi");
        if (!factoryPanel.activeSelf)
        {
            EfficiencyLevel.SetText(id[scrollManager.scroll1.SelectedFac].efficiencyLvl.ToString());
            SecurityLevel.SetText(id[scrollManager.scroll2.SelectedFac].efficiencyLvl.ToString());
            Happiness.SetText(id[scrollManager.scroll3.SelectedFac].efficiencyLvl.ToString());

            //Checks the owner of the factory after clicking on it and sends UI
            if (id[factorySelected].ownerId == 1) //If the factory is owned by the player, it will show the levels of the factory and the upgrade button
            {
                Happiness.SetText(id[factorySelected].workerHappinessLvl.ToString());
                MoneyPerS.SetText(id[factorySelected].moneyPerS.ToString());
                SecurityLevel.SetText(id[factorySelected].securityLvl.ToString());
                EfficiencyLevel.SetText(id[factorySelected].efficiencyLvl.ToString());

                UpgradeButton.SetActive(true);
                BuyButton.SetActive(false);
                SabotageButton.SetActive(false);
            }
            else //If its not owned by the player, it will show unknown values, the buy button, and the sabotage button
            {
                Happiness.SetText(unknown);
                MoneyPerS.SetText(unknown);
                SecurityLevel.SetText(unknown);
                EfficiencyLevel.SetText(unknown);

                UpgradeButton.SetActive(false);
                BuyButton.SetActive(true);
                SabotageButton.SetActive(true);
            }

            //Sets the information of the factory up          
            upgradePanel.factoryUIScript = this;
            factoryPanel.SetActive(true);
        }

        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }

    //Buy another factory
    public void BuyFactory()
    {
        if (Cid[0].companyMoney >= id[factorySelected].buyPrice)
        {
            Cid[0].companyMoney = Cid[0].companyMoney - id[factorySelected].buyPrice;

            webRequests.postBuyFactory();
        }
        else
        {
            //You dont have enough money
        }
    }

    public void HappinessUpgrade()
    {
        SecuritySelected = false;
        HappinessSelected = true;
        EfficiencySelected = false;

        if (HappLvl == 1)
        {
            cost.SetText("Cost: " + 200);
            UpgradeCost = 200;
        }
        else if (HappLvl == 2)
        {
            cost.SetText("Cost: " + 400);
            UpgradeCost = 400;
        }
        else if (HappLvl == 3)
        {
            cost.SetText("Cost: " + 600);
            UpgradeCost = 600;
        }

        currLvl.SetText("LVL " + HappLvl);
        futureLvl.SetText("LVL " + (HappLvl + 1));
        effects.SetText("This upgrade will increase the worker conditions, making your workers less likely to leave your factory.");
    }

    public void SecurityUpgrade()
    {
        SecuritySelected = true;
        HappinessSelected = false;
        EfficiencySelected = false;

        if (SecLvl == 1)
        {
            cost.SetText("Cost: " + 200);
            UpgradeCost = 200;
        }
        else if (SecLvl == 2)
        {
            cost.SetText("Cost: " + 400);
            UpgradeCost = 400;
        }
        else if (SecLvl == 3)
        {
            cost.SetText("Cost: " + 600);
            UpgradeCost = 600;
        }

        currLvl.SetText("LVL " + SecLvl);
        futureLvl.SetText("LVL " + (SecLvl + 1));
        effects.SetText("This upgrade will increase the security level of this factory, making it harder to sabotage.");
    }

    public void EfficiencyUpgrade()
    {
        SecuritySelected = false;
        HappinessSelected = false;
        EfficiencySelected = true;

        if (EffLvl == 1)
        {
            cost.SetText("Cost: " + 200);
            UpgradeCost = 200;
        }
        else if (EffLvl == 2)
        {
            cost.SetText("Cost: " + 400);
            UpgradeCost = 400;
        }
        else if (EffLvl == 3)
        {
            cost.SetText("Cost: " + 600);
            UpgradeCost = 600;
        }

        currLvl.SetText("LVL " + EffLvl);
        futureLvl.SetText("LVL " + (EffLvl + 1));
        effects.SetText("This upgrade will increase the money per second of this factory.");
    }

    public void BuyUpgrade()
    {
        if (SecuritySelected == true)
        {
            if (Cid[0].companyMoney >= UpgradeCost)
            {
                Cid[0].companyMoney = Cid[0].companyMoney - UpgradeCost;

                webRequests.postSecUpgrade();
                webRequests.getFactory();
                SecuritySelected = false;
            }
        }
        else if (HappinessSelected == true)
        {
            if (Cid[0].companyMoney >= UpgradeCost)
            {
                Cid[0].companyMoney = Cid[0].companyMoney - UpgradeCost;

                webRequests.postWCondUpgrade();
                webRequests.getFactory();
                HappinessSelected = false;
            }
        }
        else if (EfficiencySelected == true)
        {
            if (Cid[0].companyMoney >= UpgradeCost)
            {
                Cid[0].companyMoney = Cid[0].companyMoney - UpgradeCost;

                webRequests.postEffUpgrade();
                webRequests.getFactory();
                EfficiencySelected = false;
            }
        }
    }

    public void SpawnHouses()
    {
        
        for (int i = 0; i <= FacPos.Length - 1; i++)
        {

            //Gives the new POS of the clones 
            Vector2 Pos = FacPos[i].position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
            //Clones the PreFab , gets the original game objects , the new position , and rotation
        
            HousesPrefab = Instantiate(HousesPrefab, Pos, Quaternion.identity);

            //Gets the SpriteRenderer componenet
            rend = HousesPrefab.gameObject.GetComponent<SpriteRenderer>();
            //Changes the clones sorting order to 1 
            //if this is not done they default to Default Layer , and order in layer 0
            //Which makes them invisible
            rend.sortingOrder = 30;
        }
    }
    public void OnDrawGizmos()
    {
        //Makes a red cube to see the posible locations the new houses can have
        //Its not working for some reason 
        Gizmos.color = Color.red;

        for (int i = 0; i < FacPos.Length; i++)
        {
            Gizmos.DrawWireCube(FacPos[i].position, size);
        }
    }
}