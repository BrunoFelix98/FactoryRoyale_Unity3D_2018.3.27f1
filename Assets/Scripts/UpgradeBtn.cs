using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{

    public GameObject factoryUIHolder;
    private FactoryUI factoryUIScript;

    void Start()
    {
        factoryUIScript = factoryUIHolder.GetComponent<FactoryUI>();
    }
    public void TaskOnClick(GameObject upgradePanel)
    {
        if (!upgradePanel.activeSelf)
        {
            Debug.Log("You have clicked the button!");
            //set our bool to true
            upgradePanel.SetActive(true);
        }  
    }
}
