using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Values : MonoBehaviour
{
    private FactoryUI FactoryUI;
    public GameObject textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        FactoryUI = FindObjectOfType<FactoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.GetComponent<TextMeshProUGUI>().text = FactoryUI.id[0].workerHappinessLvl.ToString();
    }
}
