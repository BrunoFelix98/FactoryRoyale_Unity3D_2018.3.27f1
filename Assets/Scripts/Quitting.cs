using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Quitting : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("I can Quit");
        Application.Quit();

        System.IO.File.Delete("ParamsIndivFactory[]");
        for (int i = 0; i <= 22; i++)
        {
            System.IO.File.Delete("Factory"+i);
        }
        
    }
    
}
