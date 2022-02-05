using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //Checks if it collided with a wall if it did it keeps going
        if (other.CompareTag("HomePref" ) == true && other.CompareTag("Factories" )== true)
        {
            
        }
        Debug.Log("I got Destroyed");
        DestroyGameObject();
    }
    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
