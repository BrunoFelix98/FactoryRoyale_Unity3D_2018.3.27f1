using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public FactoryUI factoryUI;

    public static int facID;
    public static int sabotagerID;
    public static int sabotagedID;

    public void SelectSabotageLvl()
    {

        facID = factoryUI.id[factoryUI.factorySelected].id;
        sabotagerID = 1;
        sabotagedID = factoryUI.id[factoryUI.factorySelected].ownerId;

        if (factoryUI.id[factoryUI.factorySelected].securityLvl == 1)
        {
            //Loads a random level amongst all level 1
            int level1 = Random.Range(3, 5);
            SceneManager.LoadScene(level1);
        }
        else if (factoryUI.id[factoryUI.factorySelected].securityLvl == 2)
        {
            //Loads a random level amongst all level 2
            int level2 = Random.Range(6, 8);
            SceneManager.LoadScene(level2);
        }
        else if (factoryUI.id[factoryUI.factorySelected].securityLvl == 3)
        {
            //Loads a random level amongst all level 3
            int level3 = Random.Range(9, 11);
            SceneManager.LoadScene(level3);
        }
    }
}