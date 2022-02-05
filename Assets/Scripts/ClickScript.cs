using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickScript : MonoBehaviour, IPointerClickHandler
{

    public int factoryID;

    public GameObject FactoryUIGameObj;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        FactoryUIGameObj.GetComponent<FactoryUI>().factorySelected = factoryID;
        FactoryUIGameObj.GetComponent<FactoryUI>().OpenPanel();
    }

   }
