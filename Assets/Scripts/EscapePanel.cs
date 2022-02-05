using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
    public GameObject Panel;
    public FactoryUI panels;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !panels.upgradeScreen.activeSelf && !panels.factoryPanel.activeSelf)
        {
            Panel.SetActive(true);
        }
    }
}
