using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    //Gets the PreFab
    public GameObject HousesPrefab;
    //Size of the Spawning Area
    public Vector2 size;
    //Timer
    public float StartWaitTime;
    private float waitTime;
    //To Get the Sprite Renderer
    private SpriteRenderer rend;
    public Vector2 NoPos;
    private void Start()
    {
       
        waitTime = StartWaitTime;
    }
    void Update()
    {
        //Timer
        //This Needs to be changed to make them spawn due to worker amount 
        //Leave for presentation like this
        if (waitTime <= 0)
        {
            //CallsFunction 
            SpawnHouses();
            // Resets Timer
            waitTime = StartWaitTime;

        }
        //if its not time for the enemy to move to a new location , slowly decresses the wait time
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
    public void SpawnHouses()
    {
        
        //Gives the new POS of the clones 
        Vector2 Pos = gameObject.transform.position + new Vector3(Random.Range(-12 / 2 , 12 / 2 ), Random.Range(- 12/ 2, 12 / 2));
        //Clones the PreFab , gets the original game objects , the new position , and rotation
        if(Pos == NoPos )
        {
          Pos = gameObject.transform.position + new Vector3(Random.Range(-size.x / 2, 12 / 2), Random.Range(-size.y / 2, 12 / 2));
        }
        HousesPrefab = Instantiate(HousesPrefab, Pos, Quaternion.identity);
        //Gets the SpriteRenderer componenet
        rend = HousesPrefab.gameObject.GetComponent<SpriteRenderer>();
        //Changes the clones sorting order to 1 
        //if this is not done they default to Default Layer , and order in layer 0
        //Which makes them invisible
        rend.sortingOrder = 1;
    }
    public void OnDrawGizmos()
    {
        //Makes a red cube to see the posible locations the new houses can have
        //Its not working for some reason 
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position , size);
    }
}

