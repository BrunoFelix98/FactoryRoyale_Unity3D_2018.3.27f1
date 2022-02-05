using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft;
using Newtonsoft.Json;

public class WebRequests : MonoBehaviour
{
    public FactoryUI Factory;
    public ScrollManager scrollManager;
    public ChangeText Main;

    ////////////////////////////////////////////Gets///////////////////////////////////////////////////////////

    //Get methods using .Post due to the fact that the Get method does not take a form as a parameter;//

    /// <summary>
    /// Gets the money of the player;
    /// </summary>
    public void getMoney(int playerCode)
    {
        StartCoroutine(getMoneyFunc(1, playerCode));
    }

    IEnumerator getMoneyFunc(int companySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_comp", companySelected);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getMoney.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
            }
        }
    }

    /// <summary>
    /// Gets the efficiency level of the specified factory;
    /// </summary>
    public void getEffLevel(int selectedFac, int playerCode, int cost)
    {
        StartCoroutine(getEffLvl(selectedFac, playerCode, cost));
    }

    IEnumerator getEffLvl(int factorySelected, int code, int cost)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("eff_level_cost", cost);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getEffLevel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Gets the security level of the specified factory;
    /// </summary>
    public void getSecLevel(int selectedFac, int playerCode, int cost)
    {
        StartCoroutine(getSecLvl(selectedFac, playerCode, cost));
    }

    IEnumerator getSecLvl(int factorySelected, int code, int cost)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("sec_level_cost", cost);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getSecLevel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Gets the worker conditions level of the specified factory;
    /// </summary>
    public void getWCondLevel(int selectedFac, int playerCode, int cost)
    {
        StartCoroutine(getWCondLvl(selectedFac, playerCode, cost));
    }

    IEnumerator getWCondLvl(int factorySelected, int code, int cost)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("Wcond_level_cost", cost);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getWCondLevel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Gets all of the factories given the specified id;
    /// </summary>
    public void getFactory2()
    {
        StartCoroutine(getFactoryFunc2(scrollManager.Pid[0].playerCode));
    }

    IEnumerator getFactoryFunc2(int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getFactory.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<factoriesClass>>(result);

                int i = 0;

                foreach (factoriesClass fac in json)
                {
                    scrollManager.id[i].id = fac.factory_id;
                    scrollManager.id[i].factoryName = fac.factory_name;
                    scrollManager.id[i].ownerId = fac.factory_owner_id;
                    scrollManager.id[i].securityLvl = fac.factory_security_level;
                    scrollManager.id[i].workerHappinessLvl = fac.factory_worker_conditions_level;
                    scrollManager.id[i].efficiencyLvl = fac.factory_efficiency_level;
                    scrollManager.id[i].moneyPerS = fac.factory_money_per_second;
                    scrollManager.id[i].workerAmount = fac.factory_worker_amount;
                    scrollManager.id[i].houseAmount = fac.factory_house_amount;
                    scrollManager.id[i].workerHappiness = fac.factory_worker_happiness;
                    scrollManager.id[i].buyPrice = fac.factory_buy_price;
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Gets all of the factories given the specified id;
    /// </summary>
    public void getFactory()
    {
        StartCoroutine(getFactoryFunc(Factory.Pid[0].playerCode));
    }

    IEnumerator getFactoryFunc(int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getFactory.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<factoriesClass>>(result);

                int i = 0;

                foreach (factoriesClass fac in json)
                {
                    Factory.id[i].id = fac.factory_id;
                    Factory.id[i].factoryName = fac.factory_name;
                    Factory.id[i].ownerId = fac.factory_owner_id;
                    Factory.id[i].securityLvl = fac.factory_security_level;
                    Factory.id[i].workerHappinessLvl = fac.factory_worker_conditions_level;
                    Factory.id[i].efficiencyLvl = fac.factory_efficiency_level;
                    Factory.id[i].moneyPerS = fac.factory_money_per_second;
                    Factory.id[i].workerAmount = fac.factory_worker_amount;
                    Factory.id[i].houseAmount = fac.factory_house_amount;
                    Factory.id[i].workerHappiness = fac.factory_worker_happiness;
                    Factory.id[i].buyPrice = fac.factory_buy_price;
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Gets all of the factories given the specified id;
    /// </summary>
    public void getCompany()
    {
        StartCoroutine(getCompanyFunc(Factory.Pid[0].playerCode));
    }

    IEnumerator getCompanyFunc(int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getCompany.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<companiesClass>>(result);

                int i = 0;

                foreach (companiesClass comp in json)
                {
                    Factory.Cid[i].playerId = comp.player_id;
                    Factory.Cid[i].companyId = comp.company_id;
                    Factory.Cid[i].companyMoney = comp.company_money;
                    Factory.Cid[i].companyWorkerAmount = comp.company_worker_amount;
                    Factory.Cid[i].companyAmountOfFactoriesOwned = comp.company_amount_of_factories_owned;
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Gets all of the companies given the player id;
    /// </summary>
    public void getCompany2()
    {
        StartCoroutine(getCompanyFunc2(scrollManager.Pid[0].playerCode));
    }

    IEnumerator getCompanyFunc2(int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/getCompany.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<companiesClass>>(result);

                int i = 0;

                foreach (companiesClass comp in json)
                {
                    scrollManager.Cid[i].playerId = comp.player_id;
                    scrollManager.Cid[i].companyId = comp.company_id;
                    scrollManager.Cid[i].companyMoney = comp.company_money;
                    scrollManager.Cid[i].companyWorkerAmount = comp.company_worker_amount;
                    scrollManager.Cid[i].companyAmountOfFactoriesOwned = comp.company_amount_of_factories_owned;
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Gets all of the players;
    /// </summary>
    public void getPlayers2(ScrollManager scroll)
    {
        StartCoroutine(getPlayersFunc2(scroll));
    }

    IEnumerator getPlayersFunc2(ScrollManager scroll)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/FactoryRoyale/getAllPlayers.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<playerClass>>(result);

                int i = 0;

                foreach (playerClass player in json)
                {
                    scroll.Pid[i].playerCode = player.player_code;
                    scroll.Pid[i].playerCompanyName = player.player_company_name;
                    i++;
                }

                scroll.Pid[0].playerCode = scroll.Pid[Factory.Pid.Length - 1].playerCode + 1;
                PlayerPrefs.SetInt("playerconn", scroll.Pid[0].playerCode);
                postPlayer();
            }
        }
    }

    /// <summary>
    /// Gets all of the players;
    /// </summary>
    public void getPlayers3()
    {
        StartCoroutine(getPlayersFunc3());
    }

    IEnumerator getPlayersFunc3()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/FactoryRoyale/getAllPlayers.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<playerClass>>(result);

                int i = 0;

                foreach (playerClass player in json)
                {
                    Main.Pid[i].playerCode = player.player_code;
                    Main.Pid[i].playerCompanyName = player.player_company_name;
                    i++;
                }

                Main.Pid[0].playerCode = Main.Pid[Main.Pid.Length - 1].playerCode + 1;
                PlayerPrefs.SetInt("playerconn", Main.Pid[0].playerCode);
                postPlayer();
            }
        }
    }

    /// <summary>
    /// Gets all of the players;
    /// </summary>
    public void getPlayers()
    {
        StartCoroutine(getPlayersFunc());
    }

    IEnumerator getPlayersFunc()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/FactoryRoyale/getAllPlayers.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log(result);
                var json = JsonConvert.DeserializeObject<List<playerClass>>(result);

                int i = 0;

                foreach (playerClass player in json)
                {
                    Factory.Pid[i].playerCode = player.player_code;
                    Factory.Pid[i].playerCompanyName = player.player_company_name;
                    i++;
                }

                Factory.Pid[0].playerCode = Factory.Pid[Factory.Pid.Length - 1].playerCode + 1;
                PlayerPrefs.SetInt("playerconn", Factory.Pid[0].playerCode);
                postPlayer();
            }
        }
    }

    ////////////////////////////////////////////POSTS///////////////////////////////////////////////////////////

    /// <summary>
    /// Inserts new player in the database;
    /// </summary>
    public void postPlayer()
    {
        StartCoroutine(postPlayerFunc(Factory.Pid[0].playerCode));
    }

    IEnumerator postPlayerFunc(int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postPlayer.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //Buy factory

    /// <summary>
    /// Updates factory owner;
    /// </summary>
    public void postBuyFactory()
    {
        StartCoroutine(postBuyFactoryFunc(Factory.factorySelected, Factory.id[Factory.factorySelected].ownerId, Factory.Pid[0].playerCode));
    }

    IEnumerator postBuyFactoryFunc(int factorySelected, int factoryOwner, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected + 1);
        form.AddField("selected_factory_owner", factoryOwner);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postBuyFactory.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                getFactory();
            }
        }
    }

    //Buy factory for bots

    /// <summary>
    /// Updates factory owner;
    /// </summary>
    public void postBBuyFactory()
    {
        StartCoroutine(postBBuyFactoryFunc(Factory.randomComp1, Factory.randomFac1, Factory.id[Factory.randomFac1].ownerId, Factory.Pid[0].playerCode));
    }

    IEnumerator postBBuyFactoryFunc(int selectedComp, int factorySelected, int factoryOwner, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected + 1);
        form.AddField("selected_factory_owner", factoryOwner);
        form.AddField("company_selected", selectedComp);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postBBuyFactory.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                getFactory();
            }
        }
    }

    //Set the company money in the database;

    /// <summary>
    /// Updates the company money on the db;
    /// </summary>
    public void postMoney(int code, int companyMoney)
    {
        StartCoroutine(postMoneyFunc(Factory.Pid[0].playerCode, companyMoney));
    }

    IEnumerator postMoneyFunc(int code, int amountOfMoney)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_code", code);
        form.AddField("amount_of_money", amountOfMoney);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postMoney.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //Upgrades

    /// <summary>
    /// Updates the efficiency level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postEffUpgrade()
    {
        StartCoroutine(postEffUpgradeLvl(Factory.factorySelected + 1, Factory.Pid[0].playerCode));
    }

    IEnumerator postEffUpgradeLvl(int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postEffUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                getCompany();
            }
        }
    }

    /// <summary>
    /// Updates the security level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postSecUpgrade()
    {
        StartCoroutine(postSecUpgradeLvl(Factory.factorySelected + 1, Factory.Pid[0].playerCode));
    }

    IEnumerator postSecUpgradeLvl(int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postSecUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Updates the worker conditions level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postWCondUpgrade()
    {
        StartCoroutine(postWCondUpgradeLvl(Factory.factorySelected + 1, Factory.Pid[0].playerCode));
    }

    IEnumerator postWCondUpgradeLvl(int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postWCondUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //Upgrades for the bots

    /// <summary>
    /// Updates the efficiency level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postBEffUpgrade()
    {
        StartCoroutine(postBEffUpgradeLvl(Factory.randomComp1, Factory.randomFac1, Factory.Pid[0].playerCode));
    }

    IEnumerator postBEffUpgradeLvl(int selectedComp, int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("company_selected", selectedComp);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postBEffUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                getCompany();
            }
        }
    }

    /// <summary>
    /// Updates the player company name;
    /// </summary>
    public void postCompName(string compName)
    {
        StartCoroutine(postCompNameFunc(compName, Main.Pid[0].playerCode));
    }

    IEnumerator postCompNameFunc(string compname, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_company_name", compname);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postCompanyName.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                getCompany();
            }
        }
    }

    /// <summary>
    /// Updates the security level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postBSecUpgrade()
    {
        StartCoroutine(postBSecUpgradeLvl(Factory.randomComp2, Factory.randomFac2, Factory.Pid[0].playerCode));
    }

    IEnumerator postBSecUpgradeLvl(int selectedComp, int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("company_selected", selectedComp);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postBSecUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Updates the worker conditions level of the specified factory by 1 (only works for the player);
    /// </summary>
    public void postBWCondUpgrade()
    {
        StartCoroutine(postBWCondUpgradeLvl(Factory.randomComp3, Factory.randomFac3, Factory.Pid[0].playerCode));
    }

    IEnumerator postBWCondUpgradeLvl(int selectedComp, int factorySelected, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("selected_factory", factorySelected);
        form.AddField("player_code", code);
        form.AddField("company_selected", selectedComp);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postBWCondUpgrade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //Sabotages

    /// <summary>
    /// If player loses sabotage this connection is open;
    /// </summary>
    public void postLossSabotage(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        StartCoroutine(postLossSabotageFunc(sabotagerCompID, factorySelected, sabotagedCompID, Factory.Pid[0].playerCode));
    }

    IEnumerator postLossSabotageFunc(int sabotagerCompID, int factorySelected, int sabotagedCompID, int code)
    {
        WWWForm form = new WWWForm();
        form.AddField("sabotager_company_id", sabotagerCompID);
        form.AddField("selected_factory", factorySelected);
        form.AddField("sabotaged_company_id", sabotagedCompID);
        form.AddField("player_code", code);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postLossSabotage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Inserts new worker conditions and efficiency sabotage to the specified factory;
    /// </summary>
    public void postWCondAndEffSabotage(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        StartCoroutine(postWCondAndEffSabotageFunc(sabotagerCompID, factorySelected, sabotagedCompID));
    }

    IEnumerator postWCondAndEffSabotageFunc(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        WWWForm form = new WWWForm();
        form.AddField("sabotager_company_id", sabotagerCompID);
        form.AddField("selected_factory", factorySelected);
        form.AddField("sabotaged_company_id", sabotagedCompID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postWcondEffSabotage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Inserts new worker conditions sabotage to the specified factory;
    /// </summary>
    public void postWCondSabotage(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        StartCoroutine(postWCondSabotageFunc(sabotagerCompID, factorySelected, sabotagedCompID));
    }

    IEnumerator postWCondSabotageFunc(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        WWWForm form = new WWWForm();
        form.AddField("sabotager_company_id", sabotagerCompID);
        form.AddField("selected_factory", factorySelected);
        form.AddField("sabotaged_company_id", sabotagedCompID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postWcondSabotage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Inserts new efficiency sabotage to the specified factory;
    /// </summary>
    public void postEffSabotage(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        StartCoroutine(postEffSabotageFunc(sabotagerCompID, factorySelected, sabotagedCompID));
    }

    IEnumerator postEffSabotageFunc(int sabotagerCompID, int factorySelected, int sabotagedCompID)
    {
        WWWForm form = new WWWForm();
        form.AddField("sabotager_company_id", sabotagerCompID);
        form.AddField("selected_factory", factorySelected);
        form.AddField("sabotaged_company_id", sabotagedCompID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/FactoryRoyale/postEffSabotage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}