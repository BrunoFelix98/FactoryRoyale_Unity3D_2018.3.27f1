using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollPick : MonoBehaviour
{
    // Start is called before the first frame update
    private Color startcolor;
    public int Price ;
    public string Name;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI NameText;
    public int SelectedFac;
    public ScrollManager scrollManager;

    private void Start()
    {
        SelectedFac = Random.Range(2 , 23);
        Price = Random.Range(150, 1000);
        Name = "Factory " + SelectedFac;
    }
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
        PriceText.text = Price.ToString();
        NameText.text = Name.ToString();
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

    private void OnMouseDown()
    {
        if (this.name == "scroll1")
        {
            scrollManager.getEffLvl();
        }

        if (this.name == "scroll2")
        {
            scrollManager.getSecLvl();
        }

        if (this.name == "scroll3")
        {
            scrollManager.getWcondLvl();
        }
    }
}
