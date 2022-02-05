using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        //Checks if it collided with a wall if it did it keeps going
  
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Journalist");
        Debug.Log("Clicked");
    }
}
