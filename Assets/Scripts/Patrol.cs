using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //speed of the enemy
    public float speed;
    //array list with the waypoints location
    //Calling the Waypoints Position , Rotation and Scale
    public Transform[] moveSpots;
    // pick random position from movespots array
    private int randomSpots;
    // if the wait time is 3 the enemy will stand still for 3 sec
    private float waitTime;
    public float StartWaitTime;
    //Calling the Fov Class
    private FOV fov;
    //Calling the player Position , Rotation and Scale
    public Transform player;
    //Gets the specific guard
    public GameObject guard;
    private void Start()
    {
        waitTime = StartWaitTime;
        //Set randomspots varieble to a random number in the start 
        // can be equal to a number between 0 or the lenght of the array
        randomSpots = Random.Range(0 , moveSpots.Length);
        //Self explanatory 
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Awake()
    {
        //Calling the FOV class 
       fov = FindObjectOfType<FOV>();
    }
    // Update is called once per frame
    void Update()
    {
        //Checks if the raycast hit the player.
        if (fov.Following == false)
        {
            //MoveTowards(Where i want to move from , where i want to move To,speed character to move
            //MoveSpots picks a random position in the array to move towards
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);

            //Rotates the Guards in the directon the Waypoints are.
            Vector3 diff = moveSpots[randomSpots].position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        // if the raycast hits the player 
        // the guards rotate in the directon the player is.
        else
        {
           // this function is used so the guards rotate in the direction the player is in 
            transform.Rotate(guard.transform.up = player.position - transform.position);

            //if it hits the player checks the distance between the player and the enemy
            // if its bigger than the stopping distance , it starts following the player
            if (Vector2.Distance(guard.transform.position, player.position) > 4)
            {
                //Used to make the enemy follow the player
                guard.transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }


        // if statement to check if it reached the spot
        // if it reaches the spot it waits and moves to another location
        // check the distance between the enemy and the waypoint , if the distance is smaller than 0.2 f it considers it reached the waypoint , if statment returns True
        if (Vector2.Distance(transform.position , moveSpots[randomSpots].position) < 0.5f)
        {
            //checks if the waittime if less or equal to 0 , 
            //checks if its time for the enemy to move to a new location

            transform.rotation = Quaternion.Euler(0,0,0);

            if(waitTime <= 0)
            {
                //Set randomspots varieble to a random number in the start 
                // can be equal to a number between 0 or the lenght of the array
                // Since we want to move to a new location , we just copy randomSpots code again
                randomSpots = Random.Range(0, moveSpots.Length);
                 
                // Resets Timer
                waitTime = StartWaitTime;

            }
            //if its not time for the enemy to move to a new location , slowly decresses the wait time
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
