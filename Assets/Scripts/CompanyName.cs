using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CompanyName : MonoBehaviour
{
    public TextMeshProUGUI cNameText;
    public ChangeText changeTextScript;
    public GameObject CNameGameObject;

    // Start is called before the first frame update
    void Start()
    {
        CNameGameObject = GameObject.Find("RenamedComp");
        changeTextScript = CNameGameObject.GetComponent<ChangeText>();

        Debug.Log("hi");


        cNameText.SetText(changeTextScript.companyName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}